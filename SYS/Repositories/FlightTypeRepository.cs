using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Models;

namespace SYS.Repositories
{
    public class FlightTypeRepository : RepositoryBase<FlightType>, IFlightTypeRepository
    {
        public FlightTypeRepository(contextclass contextClass)
            : base(contextClass)
        {
        }
    
    }
}
