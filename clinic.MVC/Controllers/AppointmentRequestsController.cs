using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;

namespace clinic.MVC.Controllers
{
    public class AppointmentRequestsController : Controller
    {
        private readonly ApplicationContext _context;

        public AppointmentRequestsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: AppointmentRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestedAppointments.ToListAsync());
        }

        // GET: AppointmentRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRequest = await _context.RequestedAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentRequest == null)
            {
                return NotFound();
            }

            return View(appointmentRequest);
        }

        // GET: AppointmentRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientName,DocumentNumber,Phone,Email,Id,CreatedAt,UpdatedAt")] AppointmentRequest appointmentRequest)
        {
            //if (ModelState.IsValid)
            //{
            //    appointmentRequest.Id = Guid.NewGuid();
            //    _context.Add(appointmentRequest);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return View(appointmentRequest);
        }

        // GET: AppointmentRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRequest = await _context.RequestedAppointments.FindAsync(id);
            if (appointmentRequest == null)
            {
                return NotFound();
            }
            return View(appointmentRequest);
        }

        // POST: AppointmentRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ClientName,DocumentNumber,Phone,Email,Id,CreatedAt,UpdatedAt")] AppointmentRequest appointmentRequest)
        {
            if (id != appointmentRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentRequestExists(appointmentRequest.Id))
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
            return View(appointmentRequest);
        }

        // GET: AppointmentRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentRequest = await _context.RequestedAppointments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentRequest == null)
            {
                return NotFound();
            }

            return View(appointmentRequest);
        }

        // POST: AppointmentRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appointmentRequest = await _context.RequestedAppointments.FindAsync(id);
            if (appointmentRequest != null)
            {
                _context.RequestedAppointments.Remove(appointmentRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentRequestExists(Guid id)
        {
            return _context.RequestedAppointments.Any(e => e.Id == id);
        }
    }
}
