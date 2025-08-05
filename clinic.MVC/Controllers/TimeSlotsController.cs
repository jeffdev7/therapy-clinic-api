using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clinic.MVC.Controllers
{
    [Authorize]
    public class TimeSlotsController : Controller
    {
        private readonly ITimeSlotService _timeSlotServices;
        private readonly IUserService _userServices;

        public TimeSlotsController(ITimeSlotService timeSlotServices, IUserService userServices)
        {
            _timeSlotServices = timeSlotServices;
            _userServices = userServices;
        }

        // GET: TimeSlots
        public async Task<IActionResult> Index(int pageNumber)
        {
            var timeSlots = _timeSlotServices.GetAll();

            if (pageNumber < 1)
                pageNumber = 1;
            int pageSize = 6;

            return View(await Pagination<TimeSlotViewModel>.CreateAsync(timeSlots, pageNumber, pageSize));
        }

        [Authorize(Roles = "Client")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeSlotViewModel timeSlot)
        {
            var result = _timeSlotServices.AddTimeSlot(timeSlot);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                }
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Client")]
        public IActionResult Delete(Guid id)
        {
            var timeSlot = _timeSlotServices.GetById(id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        [Authorize(Roles = "Client")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _timeSlotServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
