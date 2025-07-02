using clinic.application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentVacancyController : Controller
    {
        private readonly IAppointmentVacancyServices _appointmentServices;

        public AppointmentVacancyController(IAppointmentVacancyServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }

        //[HttpGet]
        //public async Task<IEnumerable<AppointmentVacancyViewModel>> GetAppointments()
        //{
        //    return _appointmentServices.GetAll().OrderBy(_ => _.AppointmentTime);
        //}

        //[HttpGet("{id}")]
        //public async Task<AppointmentVacancyViewModel> GetById(Guid id)
        //{
        //    return _appointmentServices.GetById(id);
        //}

        //[HttpPost]
        //public async Task<ActionResult<AppointmentVacancyViewModel>> Add([FromBody] AppointmentVacancyViewModel vm)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var termine = await _appointmentServices.Add(vm);
        //    return Ok(termine);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<AppointmentVacancyViewModel>> Update([FromBody] AppointmentVacancyViewModel vm)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var termine = await _appointmentServices.Update(vm);
        //    return Ok(termine);
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var status = await _appointmentServices.Remove(id);
        //    if (!status) return BadRequest();
        //    return Ok(status);
        //}

        //[HttpGet("Total")]
        //public int GetTotal()
        //{
        //    return _appointmentServices.GetTotalOfAppointments();
        //}
    }
}