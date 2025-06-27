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
        private readonly ApplicationContext _context;

        public AppointmentRequestServices(IMapper mapper, IAppointmentRequestRepository appointmentRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
        }

        public async Task<AppointmentRequestViewModel> Add(AppointmentRequestViewModel vm)
        {
            var appointmentTime = _appointmentRepository.GetAll().Select(_ => _.RequestedTime).ToList();
            DateTime requestDate = vm.RequestedTime;

            if (appointmentTime.Contains(requestDate))
            {
                throw new Exception($"THIS DATE IS NOT AVAILABLE AT THE MOMENT.");
            }
            AppointmentRequest termine = _mapper.Map<AppointmentRequest>(vm);
            _context.RequestedAppointments.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentRequestViewModel>(termine);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AppointmentRequestViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentRequestViewModel>>(_appointmentRepository.GetAll());
        }

        public AppointmentRequestViewModel GetById(Guid id)
        {
            return _mapper.Map<AppointmentRequestViewModel>(_appointmentRepository.GetById(id));
        }

        public IEnumerable<AppointmentRequestViewModel> GetAppointment()
        {
            return _mapper.Map<IEnumerable<AppointmentRequestViewModel>>(_appointmentRepository.GetAppointments());
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
    }
}