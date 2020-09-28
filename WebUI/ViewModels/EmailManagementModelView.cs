using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class EmailManagementModelView
    {
        public int AppId { get; set; }
        public string Email { get; set; }
        public List<SelectListItem> Emails { get; set; }
    }
}
