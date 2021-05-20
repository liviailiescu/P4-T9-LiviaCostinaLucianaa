using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SYS.Models;
using SYS.Services;

namespace SYS.Controllers
{
    public class FlightReportsController : Controller
    {
        private readonly FlightReportService _flightreportService;

        public FlightReportsController(FlightReportService flightreportService)
        {
            _flightreportService = flightreportService;
        }

        // GET: FlightReports
        public IActionResult Index()
        {
            var flightreport = _flightreportService.GetFlightReport();
            return View(flightreport);
        }

        // GET: FlightReports/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightReport = _flightreportService.GetFlightReport().FirstOrDefault(m => m.FlightReportID == id);
            if (flightReport == null)
            {
                return NotFound();
            }

            return View(flightReport);
        }

        // GET: FlightReports/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: FlightReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FlightReportID,UserID,Data")] FlightReport flightReport)
        {
            if (ModelState.IsValid)
            {
                _flightreportService.AddFlightReport(flightReport);
                _flightreportService.Save();
                return RedirectToAction(nameof(Index));
            }
            
            return View(flightReport);
        }

        // GET: FlightReports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightReport = _flightreportService.GetFlightReport().FirstOrDefault(m => m.FlightReportID == id);
            if (flightReport == null)
            {
                return NotFound();
            }
            
            return View(flightReport);
        }

        // POST: FlightReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FlightReportID,UserID,Data")] FlightReport flightReport)
        {
            if (id != flightReport.FlightReportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _flightreportService.UpdateFlightReport(flightReport);
                   _flightreportService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightReportExists(flightReport.FlightReportID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(flightReport);
        }

        // GET: FlightReports/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightReport = _flightreportService.GetFlightReport().FirstOrDefault(m => m.FlightReportID == id);
            if (flightReport == null)
            {
                return NotFound();
            }

            return View(flightReport);
        }

        // POST: FlightReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flightReport = _flightreportService.GetFlightReportByCondition(b => b.FlightReportID == id).FirstOrDefault();
            _flightreportService.DeleteFlightReport(flightReport);
            _flightreportService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightReportExists(int id)
        {
            return _flightreportService.GetFlightReport().Any(e => e.FlightReportID == id);
        }
    }
}
