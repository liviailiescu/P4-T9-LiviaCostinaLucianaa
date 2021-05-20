using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class User : IdentityUser
    {
        public int UserID {get;set ;}
        public string UserName { get; set; }
        public string Prenume { get; set; }
        public char Data_nastere { get; set; }
        public string Adresa { get; set; }
        public char Nr_tel { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public object Id { get; internal set; }
        [NotMapped]
        public object PasswordHash { get; internal set; }
    }
}
