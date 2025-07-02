using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface IScheduleServices : IDisposable
    {
        ScheduleViewModel GetAll();
        Task<ScheduleViewModel> Add(ScheduleViewModel vm);
    }
}