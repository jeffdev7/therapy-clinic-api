using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface IScheduleService : IDisposable
    {
        ScheduleViewModel GetAll();
    }
}