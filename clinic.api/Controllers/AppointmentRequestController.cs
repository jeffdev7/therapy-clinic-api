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
        public async Task<IEnumerable<AppointmentRequestViewModel>> GetAppointments()
        {
            return _appointmentServices.GetAll().OrderBy(_ => _.RequestedTime);
        }

        [HttpGet("{id}")]
        public async Task<AppointmentRequestViewModel> GetById(Guid id)
        {
            return _appointmentServices.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentRequestViewModel>> Add([FromBody] AppointmentRequestViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var termine = await _appointmentServices.Add(vm);
            return Ok(termine);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentRequestViewModel>> Update([FromBody] AppointmentRequestViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var termine = await _appointmentServices.Update(vm);
            return Ok(termine);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _appointmentServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}