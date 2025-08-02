using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotService _appointmentServices;

        public TimeSlotController(ITimeSlotService appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        [HttpPost]
        public async Task<ActionResult<TimeSlotViewModel>> Add([FromBody] TimeSlotViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var termine = _appointmentServices.AddTimeSlot(vm);
            return Ok(termine);
        }

        [HttpGet]
        public IEnumerable<TimeSlotViewModel> GetAll()
        {
            return _appointmentServices.GetTimeSlot();
        }
    }
}