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

        [HttpGet]
        public ScheduleViewModel GetAll()
        {
            return _appointmentServices.GetAll();
        }
    }
}