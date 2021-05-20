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
    public class PaymentsController : Controller
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: Payments
        public IActionResult Index()
        {
            var payment = _paymentService.GetPayment();
            return View(payment);
        }

        // GET: Payments/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentService.GetPayment().FirstOrDefault(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PaymentID,UserID,ReservationID,Tip_plata,Data_plata")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _paymentService.AddPayment(payment);
                _paymentService.Save();
                return RedirectToAction(nameof(Index));
            }
            
            return View(payment);
        }

        // GET: Payments/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentService.GetPayment().FirstOrDefault(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }
            
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PaymentID,UserID,ReservationID,Tip_plata,Data_plata")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paymentService.UpdatePayment(payment);
                    _paymentService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentID))
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
            
            return View(payment);
        }

        // GET: Payments/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = _paymentService.GetPayment().FirstOrDefault(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var payment = _paymentService.GetPaymentByCondition(b => b.PaymentID == id).FirstOrDefault();
            _paymentService.DeletePayment(payment);
            _paymentService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _paymentService.GetPayment().Any(e => e.PaymentID == id);
        }
    }
}
