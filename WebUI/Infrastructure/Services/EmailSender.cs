using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Entities;
using WebUI.Interfaces;

namespace WebUI.Infrastructure.Services
{
    public class EmailSender : ISender
    {
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        public EmailSender(IConfiguration configuration, IMailService mailService)
        {
            _configuration = configuration;
            _mailService = mailService;
        }

        public void Send(Application application)
        {
            if (application.EmailAdresses.Any() && application.FailRequests.Any())
            {
                var sb = new StringBuilder();
                sb.Append("<table>");

                foreach (var failRequest in application.FailRequests)
                {
                    sb.AppendFormat("<tr><td>Date Time:</td><td>{0}</td></tr>", failRequest.DateTime);
                }
                
                sb.Append("<table>");
                
                _mailService.SendEmailAsync(new Models.MailRequest()
                {
                    ToEmail = string.Join(";",application.EmailAdresses.Select(e => e.Email)),
                    Subject = $"{application.Url} is not working",
                    Body = $"{sb.ToString()}"
                });
            }
        }
    }
}
