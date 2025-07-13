using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinic.MVC.Controllers
{
    public class AppointmentRequestsController : Controller
    {
        private readonly IAppointmentRequestServices _appointmentRequestServices;
        private readonly ITimeSlotServices _timeSlotServices;

        public AppointmentRequestsController(IAppointmentRequestServices appointmentRequestServices
            , ITimeSlotServices timeSlotServices)
        {
            _appointmentRequestServices = appointmentRequestServices;
            _timeSlotServices = timeSlotServices;
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            var appointments = _appointmentRequestServices.GetAllAppointmentsForIndex();

            if (pageNumber < 1)
                pageNumber = 1;
            int pageSize = 6;

            return View(await Pagination<AppointmentRequestIndexViewModel>.CreateAsync(appointments, pageNumber, pageSize));
        }
        public IActionResult Create()
        {
            var timeslots = _timeSlotServices.GetAvailableTimeSlots();
            var t = ViewBag.TimeSlots = timeslots.Select(_ => new SelectListItem
            {
                Value = _.Id.ToString(),
                Text = $"{_.Start:dd/MM/yyyy HH:mm} - {_.End:HH:mm}",

            }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentRequestViewModel appointmentRequest)//TODO refact
        {
            var timeslot = _timeSlotServices.GetAvailableTimeSlots()
                .SingleOrDefault(_ => _.Id == appointmentRequest.RequestedTime.Id);

            appointmentRequest.RequestedTime = new NewAppointmentTimeSlotViewModel
            {
                Id = timeslot.Id,
                Start = timeslot.Start,
                End = timeslot.End,
            };

            var result = _appointmentRequestServices.Add(appointmentRequest).GetAwaiter().GetResult();

            LoadViewBags();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            var appointment = _appointmentRequestServices.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _appointmentRequestServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        private void LoadViewBags()
        {
            ViewBag.TimeSlots = _appointmentRequestServices.GetAll().ToList();
        }
    }
}
