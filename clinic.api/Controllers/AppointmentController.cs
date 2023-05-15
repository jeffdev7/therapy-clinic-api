using clinic.application.Services.Interfaces;
using clinic.application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _appointmentServices;

        public AppointmentController(IAppointmentServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>>GetAppointments()
        {
            return  _appointmentServices.GetAll().OrderBy(_ => _.AppointmentTime);
        }

        [HttpGet("{id}")]
        public async Task<AppointmentViewModel> GetById(int id)
        {
            return _appointmentServices.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentViewModel>> Add([FromBody] AppointmentViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var termine = await _appointmentServices.Add(vm);
            return Ok(termine);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentViewModel>> Update([FromBody] AppointmentViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var termine = await _appointmentServices.Update(vm);
            return Ok(termine);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _appointmentServices.Remove(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
        [HttpGet("Total")]
        public int GetTotal()
        {
            return _appointmentServices.GetTotalOfAppointments();
        }
    }
}