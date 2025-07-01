using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;

namespace clinic.application.Services
{
    public sealed class ScheduleServices : IScheduleServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRequestRepository _appointmentRepository;
        private readonly ApplicationContext _context;

        public ScheduleServices(IMapper mapper, IAppointmentRequestRepository appointmentRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
        }


        public async Task Add(DateTime day, TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration)
        {
            var test = new Schedule();
            test.GenerateTimeSlots(day, startTime, endTime, slotDuration);

            //_context.AppointmentsVacancies.Add(termine);
            await _context.SaveChangesAsync();
            //return _mapper.Map<AppointmentVacancyViewModel>(termine);
        }
        public async Task<ScheduleAppointmentRequestViewModel> AddSchedule(ScheduleAppointmentRequestViewModel vm)
        {
            Schedule termine = _mapper.Map<Schedule>(vm);
            _context.Schedules.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<ScheduleAppointmentRequestViewModel>(termine);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}