using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentRequestController : Controller
    {
        private readonly IAppointmentRequestServices _appointmentServices;

        public AppointmentRequestController(IAppointmentRequestServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        [HttpGet]
        public IEnumerable<GetAppointmentRequestViewModel> GetAppointments()
        {
            return _appointmentServices.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentRequestViewModel>> Add([FromBody] AppointmentRequestViewModel vm)
        {
            var termine = await _appointmentServices.Add(vm);
            if (termine.IsError)
                return BadRequest(termine.Errors);
            return Ok(termine.Value);
        }
    }
}