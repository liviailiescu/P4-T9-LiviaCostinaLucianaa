using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        [ForeignKey("userida")]
        
        public int UserID { get; set; }
        
        public char Data { get; set; }
        public string Clasa { get; set; }
        public User userid { get; set; }
    }
}
