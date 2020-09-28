using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebUI.Entities;
using WebUI.Interfaces;
using WebUI.Models;
using WebUI.Utility;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ApplicationController> _logger;
        private readonly HttpClient _httpClient;
        private readonly HtmlEncoder _htmlEncoder;
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationController(IUnitOfWork unitOfWork, 
                                     IServiceProvider serviceProvider,
                                     ILogger<ApplicationController> logger,
                                     HtmlEncoder htmlEncoder,
                                     HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _serviceProvider = serviceProvider;
            _logger = logger;
            _htmlEncoder = htmlEncoder;
            _httpClient = httpClient;
        }

        #region Get View
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult GetCreateView()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult GetUpdateView(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(id);

            if (app == null)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            return PartialView("_UpdatePartial", new UpdateAppViewModel()
            {
                AppId = app.ApplicationId,
                AppName = app.Name,
                AppRequestIntervalAtMinute = app.RequestIntervalAtMinute,
                AppUrl = app.Url
            });
        }

        #endregion

        #region Crud
        // GET: ApplicationController/Get
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> GetAll(DataTableAjaxPostModel request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            Expression<Func<Application, bool>> filter = f => true;

            if (role != "Administrator")
                filter = filter.And(f => f.User.Id == userId);

            var searchValue = request?.search?.value;
            if (!string.IsNullOrEmpty(searchValue))
                filter = filter.And(f => f.Name.Contains(searchValue) || f.Url.Contains(searchValue));

            var recordsTotal = 0;
            //var pageIndex = request.start == 0 ? 1 : request.start / request.length;
            var pageIndex = (request.start / request.length) + 1;
            var appList = await _unitOfWork.Repository<Application>().FindAsync<AppViewModel>(out recordsTotal, filter: filter,
                s => new AppViewModel() { 
                    Id = s.ApplicationId,
                    Name = s.Name,
                    Url = s.Url,
                    RequestIntervalAtMinute = s.RequestIntervalAtMinute,
                    TotalRequest = s.StatisticDaily.Any() ? s.StatisticDaily.OrderByDescending(o => o.DateTime).FirstOrDefault().TotalRequest : 0,
                    SuccessRequest = s.StatisticDaily.Any() ? s.StatisticDaily.OrderByDescending(o => o.DateTime).FirstOrDefault().SuccessRequest : 0,
                    FailRequest = s.StatisticDaily.Any() ? s.StatisticDaily.OrderByDescending(o => o.DateTime).FirstOrDefault().FailRequest : 0,
                    IsRun = s.IsRun,
                },
                pageIndex, request.length);

            return Json(new { draw = request.draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = appList });
        }

        // POST: ApplicationController/Get
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Get(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(id);

            if (app == null)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            return Json(app);
        }

        // POST: ApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CreateAppViewModel request)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(request.AppUrl, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (result == false)
            {
                var ub = new UriBuilder(request.AppUrl);
                ub.Scheme = "http";
                request.AppUrl = ub.Uri.AbsoluteUri;
            }

            if (result == false)
                return BadRequest();

            _unitOfWork.Repository<Application>().Insert(new Application()
            {
                Name = _htmlEncoder.Encode(request.AppName),
                Url = _htmlEncoder.Encode(request.AppUrl),
                RequestIntervalAtMinute = request.AppRequestIntervalAtMinute,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
            });
            _unitOfWork.Save();

            return Ok();
        }

        // PUT: ApplicationController/Update
        [HttpPut]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Update(UpdateAppViewModel request)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(request.AppUrl, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (result == false)
            {
                var ub = new UriBuilder(request.AppUrl);
                ub.Scheme = "http";
                request.AppUrl = ub.Uri.AbsoluteUri;
            }

            if (result == false)
                return BadRequest();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(request.AppId);

            if (app == null || app.IsRun)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            app.Name = _htmlEncoder.Encode(request.AppName);
            app.Url = _htmlEncoder.Encode(request.AppUrl);
            app.RequestIntervalAtMinute = request.AppRequestIntervalAtMinute;

            _unitOfWork.Save();

            return Ok();
        }

        // DELETE: ApplicationController/Delete
        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(id);

            if (app == null || app.IsRun)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            _unitOfWork.Repository<Application>().Delete(id);
            _unitOfWork.Save();

            return Ok();
        }

        #endregion

        #region Run and Stop App
        // POST: ApplicationController/Run
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Run(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var application = _unitOfWork.Repository<Application>().FindById(id);

            if (application == null)
                return BadRequest();

            if (role != "Administrator" &&  application.UserId != userId)
                return BadRequest();

            if (!application.IsRun && application.RequestIntervalAtMinute > 0) {
                var jobId = Guid.NewGuid().ToString();
                RecurringJob.AddOrUpdate(jobId, () => RequestToApp(application), Cron.MinuteInterval(application.RequestIntervalAtMinute));
                application.IsRun = true;
                application.JobId = jobId;
                _unitOfWork.Save();
            }

            return Ok();
        }

        // POST: ApplicationController/Stop
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Stop(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var application = _unitOfWork.Repository<Application>().FindById(id);

            if (application == null)
                return BadRequest();

            if (role != "Administrator" && application.UserId != userId)
                return BadRequest();

            if (!string.IsNullOrEmpty(application.JobId)) { 
                RecurringJob.RemoveIfExists(application.JobId);
                application.JobId = null;
                application.IsRun = false;
                _unitOfWork.Save();
            }

            return Ok();
        }

        #endregion

        public void RequestToApp(Application application)
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var unitOfWorkFromServiceProvider = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var httpClientFromServiceProvider = serviceScope.ServiceProvider.GetRequiredService<HttpClient>();
                var waiter = httpClientFromServiceProvider.GetAsync(application.Url).GetAwaiter();
                var response = false;
                try
                {
                    response = waiter.GetResult().IsSuccessStatusCode;
                }
                catch (Exception)
                {
                    response = false;
                }

                var applicationFromRepo = unitOfWorkFromServiceProvider.Repository<Application>().FirstEntityWithEagerLoad(f => f.ApplicationId == application.ApplicationId, new string[] { "StatisticDaily" });
                var applicationStatistic = applicationFromRepo.StatisticDaily.FirstOrDefault(x => x.DateTime.Date == DateTime.Now.Date);

                if(applicationStatistic == null)
                {
                    applicationFromRepo.StatisticDaily.Add(new ApplicationStatisticDaily()
                    {
                        DateTime = DateTime.Now.Date,
                        TotalRequest = 1,
                        SuccessRequest = response ? 1 : 0,
                        FailRequest = !response ? 1 : 0,
                    });
                }
                else
                {
                    applicationStatistic.TotalRequest += 1;

                    if (response)
                        applicationStatistic.SuccessRequest += 1;
                    else
                        applicationStatistic.FailRequest += 1;
                }

                if (!response)
                    applicationFromRepo.FailRequests.Add(new ApplicationFailRequest()
                    {
                        DateTime = DateTime.Now,
                    });

                unitOfWorkFromServiceProvider.Save();
            }
        }

        #region Email
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GetEmailManagementView(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(id);

            if (app == null)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            var emails = _unitOfWork.Repository<EmailAdress>().Select(x => x.ApplicationId == id).ToList()
                                                                .Select(x => new SelectListItem()
                                                                {
                                                                    Text = x.Email,
                                                                    Value = x.Id.ToString(),
                                                                }).ToList();

            return PartialView("_EmailManagementPartial", new EmailManagementModelView() { AppId = id, Emails = emails });
        }

        // POST: ApplicationController/GetEmails
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddEmail(AddEmailViewModel request)
        {
            var valid = false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(request.Email);
                valid = addr.Address == request.Email;
            }
            catch
            {
                valid = false;
            }

            if (!valid) return BadRequest();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FirstEntityWithEagerLoad(x => x.ApplicationId == request.AppId, new string[1] { "EmailAdresses" });

            if (app == null)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            var emailAddress = new EmailAdress()
            {
                Email = _htmlEncoder.Encode(request.Email)
            };

            app.EmailAdresses.Add(emailAddress);

            _unitOfWork.Save();

            return Ok(new SelectListItem(emailAddress.Email, emailAddress.Id.ToString()));
        }

        // DELETE: ApplicationController/DeleteEmail
        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteEmail(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var emailAdress = _unitOfWork.Repository<EmailAdress>().FirstEntityWithEagerLoad(x => x.Id == id, new string[] { "Application" });

            if (emailAdress == null)
                return BadRequest();

            var app = emailAdress.Application;

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            _unitOfWork.Repository<EmailAdress>().Delete(emailAdress);

            _unitOfWork.Save();

            return Ok();
        }

        // POST: ApplicationController/GetEmails
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult GetEmails(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var app = _unitOfWork.Repository<Application>().FindById(id);

            if (app == null)
                return BadRequest();

            if (role != "Administrator" && app.UserId != userId)
                return BadRequest();

            var emails = _unitOfWork.Repository<EmailAdress>().Select(x => x.ApplicationId == id).ToList()
                                                                .Select(x => new {
                                                                    Text = x.Email,
                                                                    Id = x.Id.ToString(),
                                                                }).ToList();
            return Ok(emails);
        }
        #endregion
    }
}
