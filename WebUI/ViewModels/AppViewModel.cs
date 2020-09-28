using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class AppViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int RequestIntervalAtMinute { get; set; }
        public int SuccessRequest { get; set; }
        public int FailRequest { get; set; }
        public int TotalRequest { get; set; }
        public bool IsRun { get; set; }

    }
}
