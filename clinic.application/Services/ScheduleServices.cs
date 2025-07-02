using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
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