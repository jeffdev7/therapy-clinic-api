using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clinic.MVC.Controllers
{
    [Authorize]
    public class AppointmentRequestsController : Controller
    {
        private readonly IAppointmentRequestService _appointmentRequestServices;
        private readonly ITimeSlotService _timeSlotServices;
        private readonly IUserService _userService;

        public AppointmentRequestsController(IAppointmentRequestService appointmentRequestServices
            , ITimeSlotService timeSlotServices,
             IUserService userService)
        {
            _appointmentRequestServices = appointmentRequestServices;
            _timeSlotServices = timeSlotServices;
            _userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int pageNumber)
        {
            var appointments = _appointmentRequestServices.GetAllAppointmentsForIndex();
            if (pageNumber < 1)
                pageNumber = 1;
            int pageSize = 6;

            return View(await Pagination<AppointmentRequestIndexViewModel>.CreateAsync(appointments, pageNumber, pageSize));
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            var isAUser = _userService.GetUserId();
            if (isAUser != null)
                return RedirectToAction("Index", "AppointmentRequests");

            LoadViewBags();
            var timeslots = _timeSlotServices.GetAvailableTimeSlots();
            var t = ViewBag.TimeSlots = timeslots.Select(_ => new SelectListItem
            {
                Value = _.Id.ToString(),
                Text = $"{_.Start:dd/MM/yyyy HH:mm} - {_.End:HH:mm}",

            }).ToList();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentRequestViewModel appointmentRequest)
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

            if (result.IsError)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                LoadViewBags();
                return View(appointmentRequest);
            }
            LoadViewBags();
            TempData["SuccessMessage"] = "Appointment was made successfully.";
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Client")]
        public IActionResult Delete(Guid id)
        {
            var appointment = _appointmentRequestServices.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [Authorize(Roles = "Client")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _appointmentRequestServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSelectedUser(string userId)
        {
            var test = _userService.GetRoleByUserId(userId);

            if (test is null)
                return Json(new List<SelectListItem>());
            var slots = _timeSlotServices.GetAllByUserId(userId);

            var selectList = slots.Select(_ => new SelectListItem
            {
                Value = _.Id.ToString(),
                Text = $"{_.Start:dd/MM/yyyy HH:mm} - {_.End:HH:mm}",
            }).ToList();

            return Json(selectList);
        }
        private void LoadViewBags()
        {
            ViewBag.TimeSlots = _appointmentRequestServices.GetAll().ToList();
            ViewBag.Users = _userService.GetAllClientsUsernames();
        }
    }
}
