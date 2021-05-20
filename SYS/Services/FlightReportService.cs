using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class FlightReportService : BaseService
    {
        public FlightReportService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<FlightReport> GetFlightReport()
        {
            return repositoryWrapper.FlightReportRepository.FindAll().ToList();
        }

        public List<FlightReport> GetFlightReportByCondition(Expression<Func<FlightReport, bool>> expression)
        {
            return repositoryWrapper.FlightReportRepository.FindByCondition(expression).ToList();
        }

        public void AddFlightReport(FlightReport flightreport)
        {
            repositoryWrapper.FlightReportRepository.Create(flightreport);
        }

        public void UpdateFlightReport(FlightReport flightreport)
        {
            repositoryWrapper.FlightReportRepository.Update(flightreport);
        }

        public void DeleteFlightReport(FlightReport flightreport)
        {
            repositoryWrapper.FlightReportRepository.Delete(flightreport);
        }
    }
}

