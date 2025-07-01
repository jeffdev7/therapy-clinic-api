using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class ScheduleServices : IScheduleServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRequestRepository _appointmentRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;

        private readonly ApplicationContext _context;

        public ScheduleServices(IMapper mapper,
            IAppointmentRequestRepository appointmentRepository, ITimeSlotRepository timeSlotRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _timeSlotRepository = timeSlotRepository;
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

        public ScheduleViewModel GetAll()
        {
            var appointments = _mapper.Map<IEnumerable<AppointmentRequestViewModel>>(_appointmentRepository
                .GetAll()
                .Include(_ => _.RequestedTime)
                .OrderBy(_ => _.RequestedTime.IsBooked));

            var slots = _mapper.Map<IEnumerable<TimeSlotViewModel>>(_timeSlotRepository
                .GetAll()
                .Where(_ => _.IsBooked == false));

            return new ScheduleViewModel
            {
                Appointments = appointments,
                AvailableSlots = slots
            };
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}