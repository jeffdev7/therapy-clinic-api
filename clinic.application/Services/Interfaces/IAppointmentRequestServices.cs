using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface IAppointmentRequestServices : IDisposable
    {
        IEnumerable<GetAppointmentRequestViewModel> GetAll();
        Task<AppointmentRequestViewModel> Update(AppointmentRequestViewModel vm);
        Task<AppointmentRequestViewModel> Add(AppointmentRequestViewModel vm);
        Task<bool> Remove(Guid id);
    }
}