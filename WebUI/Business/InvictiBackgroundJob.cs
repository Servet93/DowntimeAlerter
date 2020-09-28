using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entities;
using WebUI.Interfaces;

namespace WebUI.Business
{
    public class InvictiBackgroundJob : IBackgroundJob
    {
        private readonly IServiceProvider _serviceProvider;
        public InvictiBackgroundJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var notificationSystemFromServiceProvider = serviceScope.ServiceProvider.GetRequiredService<INotificationSystem>();
                notificationSystemFromServiceProvider.Notify();
            }
        }
    }
}
