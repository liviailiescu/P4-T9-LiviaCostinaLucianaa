using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Models
{
    public class contextclass : IdentityDbContext<IdentityUser> 
    {
        public contextclass (DbContextOptions<contextclass>options)
            :base(options)
        { }
        public DbSet<User> User { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightType> FlightTypes { get; set; }
        public DbSet<FlightReport> FlightReports { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
