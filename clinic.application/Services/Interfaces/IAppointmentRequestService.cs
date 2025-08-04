using clinic.CrossCutting.Dto;
using ErrorOr;

namespace clinic.application.Services.Interfaces
{
    public interface IAppointmentRequestService : IDisposable
    {
        IEnumerable<GetAppointmentRequestViewModel> GetAll();
        IQueryable<AppointmentRequestIndexViewModel> GetAllAppointmentsForIndex();
        Task<ErrorOr<AppointmentRequestViewModel>> Add(AppointmentRequestViewModel vm);
        Task<bool> Remove(Guid id);
        AppointmentRequestViewModel GetById(Guid id);
    }
}