using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Application> Applications { get; set; }
    }
}
