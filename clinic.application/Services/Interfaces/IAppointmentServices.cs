using clinic.application.ViewModel;
using clinic.domain.Entities;

namespace clinic.application.Services.Interfaces
{
    public interface IAppointmentServices : IDisposable
    {
        IEnumerable<AppointmentViewModel> GetAll();
        AppointmentViewModel GetById(int id);
        IEnumerable<AppointmentViewModel> GetAllBy(Func<Appointment, bool> exp);
        Task<AppointmentViewModel> Update(AppointmentViewModel vm);
        Task<AppointmentViewModel> Add(AppointmentViewModel vm);
        Task<bool> Remove(int id);
        IEnumerable<AppointmentViewModel> GetAppointment();
        int GetTotalOfAppointments();
    }
}