using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain;
using clinic.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clinic.MVC.Controllers
{
    public class TimeSlotsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ITimeSlotServices _timeSlotServices;

        public TimeSlotsController(ApplicationContext context, ITimeSlotServices timeSlotServices)
        {
            _context = context;
            _timeSlotServices = timeSlotServices;
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

        // GET: TimeSlots/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeSlotViewModel timeSlot)
        {
            var test = await _timeSlotServices.AddTimeSlot(timeSlot);
            return RedirectToAction(nameof(Index));
        }

        // GET: TimeSlots/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Start,End,IsBooked,Id,CreatedAt,UpdatedAt")] TimeSlot timeSlot)
        {
            if (id != timeSlot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSlot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSlotExists(timeSlot.Id))
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
            return View(timeSlot);
        }

        // GET: TimeSlots/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeSlot = await _context.TimeSlots
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot != null)
            {
                _context.TimeSlots.Remove(timeSlot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSlotExists(Guid id)
        {
            return _context.TimeSlots.Any(e => e.Id == id);
        }
    }
}
