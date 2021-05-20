using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYS.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        IFlightRepository FlightRepository { get; }
        IFlightTypeRepository FlightTypeRepository { get; }
        IFlightReportRepository FlightReportRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IAirplaneRepository AirplaneRepository { get; }
        void Save();
    }
}
