using clinic.domain.Entities;

namespace clinic.data.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IQueryable<Appointment> GetAppointments();
    }
}