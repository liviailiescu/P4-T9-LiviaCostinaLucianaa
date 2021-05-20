using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class FlightService : BaseService
    {
        public FlightService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Flight> GetFlight()
        {
            return repositoryWrapper.FlightRepository.FindAll().ToList();
        }

        public List<Flight> GetFlightByCondition(Expression<Func<Flight, bool>> expression)
        {
            return repositoryWrapper.FlightRepository.FindByCondition(expression).ToList();
        }

        public void AddFlight(Flight flight)
        {
            repositoryWrapper.FlightRepository.Create(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            repositoryWrapper.FlightRepository.Update(flight);
        }

        public void DeleteFlight(Flight flight)
        {
            repositoryWrapper.FlightRepository.Delete(flight);
        }
    }
}
