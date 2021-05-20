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
    public class FlightTypesController : Controller
    {
        private readonly FlightTypeService _flighttypeService;

        public FlightTypesController(FlightTypeService flightTypeService)
        {
            _flighttypeService = flightTypeService;
        }

        // GET: FlightTypes
        public IActionResult Index()
        {
            var flighttype = _flighttypeService.GetFlightType();
            return View(flighttype);
        }

        // GET: FlightTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var flightType = _flighttypeService.GetFlightType().FirstOrDefault(m => m.FLightTypeID == id);
                if (flightType == null)
            {
                return NotFound();
            }

            return View(flightType);
        }

        // GET: FlightTypes/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: FlightTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FLightTypeID,AirplaneID,Nr_Locuri,Plecare,Ora_plecare,Sosire,Ora_sosire")] FlightType flightType)
        {
            if (ModelState.IsValid)
            {
                _flighttypeService.AddFlightType(flightType);
                _flighttypeService.Save();
                return RedirectToAction(nameof(Index));
            }
           
            return View(flightType);
        }

        // GET: FlightTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightType = _flighttypeService.GetFlightType().FirstOrDefault(m => m.FLightTypeID == id);
            if (flightType == null)
            {
                return NotFound();
            }
            
            return View(flightType);
        }

        // POST: FlightTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FLightTypeID,AirplaneID,Nr_Locuri,Plecare,Ora_plecare,Sosire,Ora_sosire")] FlightType flightType)
        {
            if (id != flightType.FLightTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _flighttypeService.UpdateFlightType(flightType);
                    _flighttypeService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightTypeExists(flightType.FLightTypeID))
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
            
            return View(flightType);
        }

        // GET: FlightTypes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightType = _flighttypeService.GetFlightType().FirstOrDefault(m => m.FLightTypeID == id);
            if (flightType == null)
            {
                return NotFound();
            }

            return View(flightType);
        }

        // POST: FlightTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var flightType = _flighttypeService.GetFlightTypeByCondition(b => b.FLightTypeID == id).FirstOrDefault();
            _flighttypeService.DeleteFlightType(flightType);
            _flighttypeService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightTypeExists(int id)
        {
            return _flighttypeService.GetFlightType().Any(e => e.FLightTypeID == id);
        }
    }
}
