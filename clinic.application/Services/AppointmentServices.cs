using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.application.ViewModel;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class AppointmentServices : IAppointmentServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ApplicationContext _context;

        public AppointmentServices(IMapper mapper, IAppointmentRepository appointmentRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
        }

        public async Task<AppointmentViewModel> Add(AppointmentViewModel vm)
        {
            var appointmentTime = _appointmentRepository.GetAll().Select(_ => _.AppointmentTime).ToList();
            DateTime requestDate = vm.AppointmentTime;

            if (appointmentTime.Contains(requestDate))
            {
                throw new Exception($"THIS DATE IS NOT AVAILABLE AT THE MOMENT.");
            }
            Appointment termine = _mapper.Map<Appointment>(vm);
            _context.Appointments.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentViewModel>(termine);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.GetAll());
        }

        public IEnumerable<AppointmentViewModel> GetAllBy(Func<Appointment, bool> exp)
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.GetAllBy(exp));
        }

        public AppointmentViewModel GetById(int id)
        {
            return _mapper.Map<AppointmentViewModel>(_appointmentRepository.GetById(id));
        }

        public IEnumerable<AppointmentViewModel> GetAppointment()
        {
            return _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentRepository.GetAppointments());
        }
        public int GetTotalOfAppointments()
        {
            return _appointmentRepository.GetTotalOfAppointments();
        }

        public async Task<bool> Remove(int id)
        {
            Appointment termine = await _context.Appointments
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (termine == null)
                return false;
            _context.Appointments.Remove(termine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AppointmentViewModel> Update(AppointmentViewModel vm)
        {
            Appointment termine = _mapper.Map<Appointment>(vm);
            _context.Appointments.Update(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentViewModel>(termine);
        }
    }
}