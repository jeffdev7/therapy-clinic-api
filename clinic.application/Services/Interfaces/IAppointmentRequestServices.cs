using clinic.CrossCutting.Dto;
using ErrorOr;

namespace clinic.application.Services.Interfaces
{
    public interface IAppointmentRequestServices : IDisposable
    {
        IEnumerable<GetAppointmentRequestViewModel> GetAll();
        Task<AppointmentRequestViewModel> Update(AppointmentRequestViewModel vm);
        Task<ErrorOr<AppointmentRequestViewModel>> Add(AppointmentRequestViewModel vm);
        Task<bool> Remove(Guid id);
    }
}