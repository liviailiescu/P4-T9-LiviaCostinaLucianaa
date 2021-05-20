using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class Flight
    {
        public int FlightID { get; set; }

        [ForeignKey("airplanea")]
        public int AirplaneID { get; set; }

        [ForeignKey("reservationa")]
        public int ReservationID { get; set; }
        

        public Airplane airplane { get; set; }
        public Reservation reservation { get; set; }


    }

}
