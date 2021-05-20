using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class AirplaneService :BaseService
    {
        public AirplaneService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Airplane> GetAirplane()
        {
            return repositoryWrapper.AirplaneRepository.FindAll().ToList();
        }

        public List<Airplane> GetAirplaneByCondition(Expression<Func<Airplane, bool>> expression)
        {
            return repositoryWrapper.AirplaneRepository.FindByCondition(expression).ToList();
        }

        public void AddAirplane(Airplane airplane)
        {
            repositoryWrapper.AirplaneRepository.Create(airplane);
        }

        public void UpdateAirplane(Airplane airplane)
        {
            repositoryWrapper.AirplaneRepository.Update(airplane);
        }

        public void DeleteAirplane(Airplane airplane)
        {
            repositoryWrapper.AirplaneRepository.Delete(airplane);
        }
    }
}

