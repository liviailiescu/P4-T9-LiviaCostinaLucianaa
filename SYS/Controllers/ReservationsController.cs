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
    public class ReservationsController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationsController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: Reservations
        public IActionResult Index()
        {
            var reservation = _reservationService.GetReservation();
            return View(reservation);
        }

        // GET: Reservations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservation().FirstOrDefault(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ReservationID,UserID,Data,Clasa")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationService.AddReservation(reservation);
                _reservationService.Save();
                return RedirectToAction(nameof(Index));
            }
           
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservation().FirstOrDefault(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }
            
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ReservationID,UserID,Data,Clasa")] Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reservationService.UpdateReservation(reservation);
                    _reservationService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationID))
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
          
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = _reservationService.GetReservation().FirstOrDefault(m => m.ReservationID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reservation = _reservationService.GetReservationByCondition(b => b.ReservationID == id).FirstOrDefault();
            _reservationService.DeleteReservation(reservation);
            _reservationService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _reservationService.GetReservation().Any(e => e.ReservationID == id);
        }
    }
}
