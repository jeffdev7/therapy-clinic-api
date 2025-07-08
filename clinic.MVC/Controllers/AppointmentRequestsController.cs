using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain;
using clinic.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace clinic.MVC.Controllers
{
    public class AppointmentRequestsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IAppointmentRequestServices _appointmentRequestServices;
        private readonly ITimeSlotServices _timeSlotServices;

        public AppointmentRequestsController(ApplicationContext context, IAppointmentRequestServices appointmentRequestServices
            , ITimeSlotServices timeSlotServices)
        {
            _context = context;
            _appointmentRequestServices = appointmentRequestServices;
            _timeSlotServices = timeSlotServices;
        }

        // GET: AppointmentRequests
        public async Task<IActionResult> Index(int pageNumber)
        {
            var appointments = _appointmentRequestServices.GetAllAppointments();

            if (pageNumber < 1)
                pageNumber = 1;
            int pageSize = 6;

            return View(await Pagination<AppointmentRequestViewModel>.CreateAsync(appointments, pageNumber, pageSize));
        }

        // GET: AppointmentRequests/Create
        public IActionResult Create()
        {
            var timeslots = _timeSlotServices.GetAvailableTimeSlots();
            var t = ViewBag.TimeSlots = timeslots.Select(_ => new SelectListItem
            {
                Value = _.Id.ToString(),
                Text = $"{_.Start:dd/MM/yyyy HH:mm} - {_.End:dd/MM/yyyy HH:mm}",

            }).ToList();
            return View();
        }

        // POST: AppointmentRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentRequestViewModel appointmentRequest)
        {
            var result = _appointmentRequestServices.Add(appointmentRequest).GetAwaiter().GetResult();

            LoadViewBags();



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
        private void LoadViewBags()
        {
            ViewBag.TimeSlots = _appointmentRequestServices.GetAll().ToList();
        }
    }
}
