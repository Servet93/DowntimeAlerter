using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities
{
    public class ApplicationStatisticDaily
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int TotalRequest { get; set; }
        public int FailRequest { get; set; }
        public int SuccessRequest { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Application Application { get; set; }
    }
}
