using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IAppointmentVacancyRepository : IRepository<AppointmentVacancy>
    {
        IQueryable<AppointmentVacancy> GetAppointments();
        int GetTotalOfAppointments();
    }
}