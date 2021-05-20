using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class FlightReport
    {
        public int FlightReportID { get; set; }

        [ForeignKey("usera")]
        public int UserID { get; set; }
       
        public char Data { get; set; }
        public User user { get; set; }
    }
}
