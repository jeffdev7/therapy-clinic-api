using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface IAppointmentVacancyServices : IDisposable
    {
        IList<AppointmentVacancyViewModel> GetAll();
        AppointmentVacancyViewModel GetById(Guid id);
        Task<AppointmentVacancyViewModel> Update(AppointmentVacancyViewModel vm);
        Task<AppointmentVacancyViewModel> Add(AppointmentVacancyViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<AppointmentVacancyViewModel> GetAppointment();
        IQueryable<AppointmentVacancyViewModel> GetAllAppointment();
        int GetTotalOfAppointments();
    }
}