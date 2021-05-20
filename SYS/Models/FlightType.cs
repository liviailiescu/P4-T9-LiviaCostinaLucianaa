using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class FlightType
    {
        public int FLightTypeID { get; set; }

        [ForeignKey("airplane")]
        public int AirplaneID { get; set; }
       

        public int Nr_Locuri { get; set; }
        public string Plecare { get; set; }
        public char Ora_plecare { get; set; }
        public string Sosire { get; set; }
        public char Ora_sosire { get; set; }
        public Airplane airplane { get; set; }
    }
}
