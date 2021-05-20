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
    public class AirplanesController : Controller
    {
        private readonly AirplaneService _airplaneService;

        public AirplanesController(AirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        // GET: Airplanes
        public  IActionResult Index()
        {
            var airplanes = _airplaneService.GetAirplane();
            return View(airplanes);
        }

        // GET: Airplanes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _airplaneService.GetAirplane().FirstOrDefault(m => m.AirplaneID == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AirplaneID,Tip_avion,Nume")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                _airplaneService.AddAirplane(airplane);
                _airplaneService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _airplaneService.GetAirplane().FirstOrDefault(m => m.AirplaneID == id);
            if (airplane == null)
            {
                return NotFound();
            }
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AirplaneID,Tip_avion,Nume")] Airplane airplane)
        {
            if (id != airplane.AirplaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _airplaneService.UpdateAirplane(airplane);
                     _airplaneService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirplaneExists(airplane.AirplaneID))
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
            return View(airplane);
        }

        // GET: Airplanes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = _airplaneService.GetAirplane().FirstOrDefault(m => m.AirplaneID == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var airplane = _airplaneService.GetAirplaneByCondition(b => b.AirplaneID == id).FirstOrDefault();
            _airplaneService.DeleteAirplane(airplane);
            _airplaneService.Save();           
            return RedirectToAction(nameof(Index));
        }

        private bool AirplaneExists(int id)
        {
            return _airplaneService.GetAirplane().Any(e => e.AirplaneID == id);
        }
    }
}
