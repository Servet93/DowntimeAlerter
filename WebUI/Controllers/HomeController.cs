using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebUI.Models;
using WebUI.Entities;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(IServiceProvider serviceProvider, ILogger<HomeController> logger, HttpClient httpClient)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _httpClient = httpClient;

            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public void RequestToApp(Application application)
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var httpClientFromServiceProvider = serviceScope.ServiceProvider.GetRequiredService<HttpClient>();
                var response = httpClientFromServiceProvider.GetAsync(application.Url).Result;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestToSite(string url)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            
            if (result == false)
            {
                var ub = new UriBuilder(url);
                ub.Scheme = "http";
                url = ub.Uri.AbsoluteUri;
            }

            result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if(result == false)
                return BadRequest();

            var response = false;

            try
            {
                var httpResponse = await _httpClient.GetAsync(url);
                response = httpResponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                response = false;
            }

            if(!response)
                return BadRequest();

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

