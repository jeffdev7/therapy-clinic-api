using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IQueryable<Appointment> GetAppointments();
        int GetTotalOfAppointments();
    }
}