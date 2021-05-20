using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [ForeignKey("usera")]
        public int UserID { get; set; }
        [ForeignKey("reservationa")]
        public int ReservationID { get; set; }
       
        public string Tip_plata { get; set; }
        public char Data_plata { get; set; }
        public User user { get; set; }
        public Reservation reservation { get; set; }
    }
}
