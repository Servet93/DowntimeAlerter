using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities
{
    public class EmailAdress
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual Application Application{ get; set; }
        public int ApplicationId { get; set; }
    }
}
