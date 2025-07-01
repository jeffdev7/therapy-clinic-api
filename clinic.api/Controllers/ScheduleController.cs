using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleServices _appointmentServices;

        public ScheduleController(IScheduleServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleViewModel>> Add([FromBody] ScheduleAppointmentRequestViewModel vm)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var termine = await _appointmentServices.AddSchedule(vm);
                return Ok(termine);
            }


        }
    }
}