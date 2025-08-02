using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;

namespace clinic.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _appointmentServices;

        public ScheduleController(IScheduleService appointmentServices)
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