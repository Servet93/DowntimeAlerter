using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entities;
using WebUI.Interfaces;

namespace WebUI.Infrastructure.Services
{
    public class NotificationSystem : INotificationSystem
    {
        private readonly IUnitOfWork _unitOfWork;
        List<ISender> senders = new List<ISender>();
        public NotificationSystem(IUnitOfWork unitOfWork, EmailSender emailSender,SmsSender smsSender)
        {
            _unitOfWork = unitOfWork;
            senders.Add(emailSender);
            senders.Add(smsSender);
        }

        public void Notify()
        {
            var applicationFailRequests = _unitOfWork.Repository<Application>();
            var applications = applicationFailRequests.EntityWithEagerLoad(null, new string[2] { "FailRequests", "EmailAdresses" });

            foreach (var sender in senders)
            {
                foreach (var application in applications)
                {
                    sender.Send(application);
                }
                
            }

            foreach (var app in applications) {
                foreach (var fail in app.FailRequests)
                    _unitOfWork.Repository<ApplicationFailRequest>().Delete(fail);
            }

            _unitOfWork.Save();
        }
    }
}
