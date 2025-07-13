using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IAppointmentRequestRepository : IRepository<AppointmentRequest>
    {
        IQueryable<AppointmentRequest> GetAppointments();
        AppointmentRequest GetAppointmentRequestById(Guid id);
    }
}