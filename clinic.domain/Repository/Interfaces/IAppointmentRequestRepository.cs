using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IAppointmentRequestRepository : IRepository<AppointmentRequest>
    {
        AppointmentRequest GetAppointmentRequestById(Guid id);
        Task AddAppointment(AppointmentRequest appointmentRequest);
        AppointmentRequest GetAppointmentById(Guid id);
        Task RemoveAppointmentRequest(AppointmentRequest appointment);
    }
}