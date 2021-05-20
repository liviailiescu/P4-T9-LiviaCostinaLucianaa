using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Models;

namespace SYS.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private contextclass _contextClass;
        private IUserRepository _userRepository;
        private IFlightRepository _flightRepository;
        private IFlightTypeRepository _flighttypeRepository;
        private IFlightReportRepository _flightreportRepository;
        private IReservationRepository _reservationRepository;
        private IPaymentRepository _paymentRepository;
        private IAirplaneRepository _airplaneRepository;


        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_contextClass);
                }
                return _userRepository;
            }
        }
        public IFlightRepository FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new FlightRepository(_contextClass);
                }
                return _flightRepository;
            }
        }
        public IFlightTypeRepository FlightTypeRepository
        {
            get
            {
                if (_flighttypeRepository == null)
                {
                    _flighttypeRepository = new FlightTypeRepository(_contextClass);
                }
                return _flighttypeRepository;
            }
        }
        public IFlightReportRepository FlightReportRepository
        {
            get
            {
                if (_flightreportRepository == null)
                {
                    _flightreportRepository = new FlightReportRepository(_contextClass);
                }
                return _flightreportRepository;
            }
        }
        public IReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_contextClass);
                }
                return _reservationRepository;
            }
        }
        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_contextClass);
                }
                return _paymentRepository;
            }
        }
        public IAirplaneRepository AirplaneRepository
        {
            get
            {
                if (_airplaneRepository == null)
                {
                    _airplaneRepository = new AirplaneRepository(_contextClass);
                }
                return _airplaneRepository;
            }
        }
        public RepositoryWrapper(contextclass contextClass)
        {
            _contextClass = contextClass;
        }

        public void Save()
        {
            _contextClass.SaveChanges();
        }
    }
}
