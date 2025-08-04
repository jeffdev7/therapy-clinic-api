using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IAppointmentRequestRepository : IRepository<AppointmentRequest>
    {
        AppointmentRequest GetAppointmentRequestById(Guid id);
    }
}