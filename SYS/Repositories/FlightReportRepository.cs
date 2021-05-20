using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Models;

namespace SYS.Repositories
{
    public class FlightReportRepository : RepositoryBase<FlightReport>, IFlightReportRepository
    {
        public FlightReportRepository(contextclass contextClass)
            : base(contextClass)
        {
        }
    
    }
}
