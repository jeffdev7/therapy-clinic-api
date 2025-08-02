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
        private readonly ITimeSlotServices _timeSlotServices;
        private readonly IUserServices _userServices;

        public TimeSlotsController(ITimeSlotServices timeSlotServices, IUserServices userServices)
        {
            _timeSlotServices = timeSlotServices;
            _userServices = userServices;
        }

        // GET: TimeSlots
        public async Task<IActionResult> Index(int pageNumber)
        {
            var timeSlots = _timeSlotServices.GetAll();
            bool isClient = await _userServices.GetCurrentUser(User);//guess wont need it

            ViewBag.IsClient = isClient;

            if (pageNumber < 1)
                pageNumber = 1;
            int pageSize = 6;

            return View(await Pagination<TimeSlotViewModel>.CreateAsync(timeSlots, pageNumber, pageSize));
        }

        // GET: TimeSlots/Create
        public IActionResult Create()
        {
            return View();
        }

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

        // GET: TimeSlots/Delete/5
        public IActionResult Delete(Guid id)
        {
            var timeSlot = _timeSlotServices.GetById(id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return View(timeSlot);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _timeSlotServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
