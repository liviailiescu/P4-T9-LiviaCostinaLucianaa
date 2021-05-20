using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class FlightTypeService :BaseService
    {
        public FlightTypeService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<FlightType> GetFlightType()
        {
            return repositoryWrapper.FlightTypeRepository.FindAll().ToList();
        }

        public List<FlightType> GetFlightTypeByCondition(Expression<Func<FlightType, bool>> expression)
        {
            return repositoryWrapper.FlightTypeRepository.FindByCondition(expression).ToList();
        }

        public void AddFlightType(FlightType flighttype)
        {
            repositoryWrapper.FlightTypeRepository.Create(flighttype);
        }

        public void UpdateFlightType(FlightType flighttype)
        {
            repositoryWrapper.FlightTypeRepository.Update(flighttype);
        }

        public void DeleteFlightType(FlightType flighttype)
        {
            repositoryWrapper.FlightTypeRepository.Delete(flighttype);
        }
    }
}

