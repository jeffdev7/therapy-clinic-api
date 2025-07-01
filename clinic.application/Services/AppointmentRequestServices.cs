using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class AppointmentRequestServices : IAppointmentRequestServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRequestRepository _appointmentRepository;
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly ApplicationContext _context;

        public AppointmentRequestServices(IMapper mapper, IAppointmentRequestRepository appointmentRepository, ITimeSlotRepository timeSlotRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task<AppointmentRequestViewModel> Add(AppointmentRequestViewModel vm)
        {
            var timeSlots = _timeSlotRepository.GetAll().ToList();

            AppointmentRequest termine = _mapper.Map<AppointmentRequest>(vm);

            foreach (var timeSlot in timeSlots)
            {
                if (timeSlot.Start == termine.RequestedTime.Start
                    && timeSlot.End == termine.RequestedTime.End
                    && timeSlot.IsBooked is false)
                {
                    _context.Entry(timeSlot).State = EntityState.Modified;
                    timeSlot.IsBooked = true;
                    _timeSlotRepository.Update(timeSlot);
                }

            }

            _context.Attach(termine.RequestedTime);
            _context.RequestedAppointments.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentRequestViewModel>(termine);
        }

        public IEnumerable<AppointmentRequestViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentRequestViewModel>>(_appointmentRepository
                .GetAll()
                .Include(_ => _.RequestedTime)
                .OrderBy(_ => _.RequestedTime.IsBooked));
        }

        public async Task<bool> Remove(Guid id)
        {
            AppointmentRequest termine = await _context.RequestedAppointments
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (termine == null)
                return false;
            _context.RequestedAppointments.Remove(termine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AppointmentRequestViewModel> Update(AppointmentRequestViewModel vm)
        {
            AppointmentRequest termine = _mapper.Map<AppointmentRequest>(vm);
            _context.RequestedAppointments.Update(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentRequestViewModel>(termine);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}