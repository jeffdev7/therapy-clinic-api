using AutoMapper;
using clinic.application.Services.Interfaces;
using clinic.CrossCutting.Dto;
using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clinic.application.Services
{
    public sealed class AppointmentVacancyServices : IAppointmentVacancyServices
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentVacancyRepository _appointmentRepository;
        private readonly ApplicationContext _context;

        public AppointmentVacancyServices(IMapper mapper, IAppointmentVacancyRepository appointmentRepository,
            ApplicationContext context)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _context = context;
        }

        public async Task<AppointmentVacancyViewModel> Add(AppointmentVacancyViewModel vm)
        {
            var appointmentTime = _appointmentRepository.GetAll().Select(_ => _.AppointmentTime).ToList();
            //DateTime requestDate = vm.AppointmentTime;

            //if (appointmentTime.Contains(requestDate))
            //{
            //    throw new Exception($"THIS DATE IS NOT AVAILABLE AT THE MOMENT.");
            //}
            AppointmentVacancy termine = _mapper.Map<AppointmentVacancy>(vm);
            _context.AppointmentsVacancies.Add(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentVacancyViewModel>(termine);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AppointmentVacancyViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<AppointmentVacancyViewModel>>(_appointmentRepository.GetAll());
        }

        public AppointmentVacancyViewModel GetById(Guid id)
        {
            return _mapper.Map<AppointmentVacancyViewModel>(_appointmentRepository.GetById(id));
        }

        public IEnumerable<AppointmentVacancyViewModel> GetAppointment()
        {
            return _mapper.Map<IEnumerable<AppointmentVacancyViewModel>>(_appointmentRepository.GetAppointments());
        }

        public async Task<bool> Remove(Guid id)
        {
            AppointmentVacancy termine = await _context.AppointmentsVacancies
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (termine == null)
                return false;
            _context.AppointmentsVacancies.Remove(termine);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AppointmentVacancyViewModel> Update(AppointmentVacancyViewModel vm)
        {
            AppointmentVacancy termine = _mapper.Map<AppointmentVacancy>(vm);
            _context.AppointmentsVacancies.Update(termine);
            await _context.SaveChangesAsync();
            return _mapper.Map<AppointmentVacancyViewModel>(termine);
        }

        public int GetTotalOfAppointments()
        {
            throw new NotImplementedException();
        }
    }
}