using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;

namespace clinic.data.Repositories
{
    public sealed class AppointmentVacancyRepository : Repository<AppointmentVacancy>, IAppointmentVacancyRepository
    {
        public AppointmentVacancyRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<AppointmentVacancy> GetAppointments()
        {
            return _context.AppointmentsVacancies;
        }
        public int GetTotalOfAppointments()
        {
            return _context.AppointmentsVacancies.Count();
        }

    }
}