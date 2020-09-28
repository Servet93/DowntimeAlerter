﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class UpdateAppViewModel
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public string AppUrl { get; set; }
        public int AppRequestIntervalAtMinute { get; set; }
    }
}
