using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class ReservationService :BaseService
    {
        public ReservationService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Reservation> GetReservation()
        {
            return repositoryWrapper.ReservationRepository.FindAll().ToList();
        }

        public List<Reservation> GetReservationByCondition(Expression<Func<Reservation, bool>> expression)
        {
            return repositoryWrapper.ReservationRepository.FindByCondition(expression).ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            repositoryWrapper.ReservationRepository.Create(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            repositoryWrapper.ReservationRepository.Update(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            repositoryWrapper.ReservationRepository.Delete(reservation);
        }
    }
}

