using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entities;

namespace WebUI.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int RequestIntervalAtMinute { get; set; }
        public bool IsRun { get; set; }
        public string JobId { get; set; }
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ApplicationStatisticDaily> StatisticDaily { get; private set; } = new List<ApplicationStatisticDaily>();
        public virtual ICollection<EmailAdress> EmailAdresses { get; private set; } = new List<EmailAdress>();
        public virtual ICollection<ApplicationFailRequest> FailRequests { get; private set; } = new List<ApplicationFailRequest>();
    }
}
