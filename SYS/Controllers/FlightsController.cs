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
    public class FlightsController : Controller
    {
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService)
        {
            _flightService= flightService;
        }

        // GET: Flights
        public IActionResult Index()
        {
            var flight = _flightService.GetFlight();
            return View(flight);
        }

        // GET: Flights/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flightService.GetFlight().FirstOrDefault(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FlightID,AirplaneID,ReservationID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _flightService.AddFlight(flight);
                _flightService.Save();
                return RedirectToAction(nameof(Index));
            }
           
            return View(flight);
        }

        // GET: Flights/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flightService.GetFlight().FirstOrDefault(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }
            
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FlightID,AirplaneID,ReservationID")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _flightService.UpdateFlight(flight);
                    _flightService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
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
            
            
            return View(flight);
        }

        // GET: Flights/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = _flightService.GetFlight().FirstOrDefault(m => m.FlightID == id);

            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flight = _flightService.GetFlightByCondition(b => b.FlightID == id).FirstOrDefault();
            _flightService.DeleteFlight(flight);
            _flightService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _flightService.GetFlight().Any(e => e.FlightID == id);
        }
    }
}
