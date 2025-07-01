using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface IScheduleServices : IDisposable
    {
        Task Add(DateTime day, TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration);
        Task<ScheduleAppointmentRequestViewModel> AddSchedule(ScheduleAppointmentRequestViewModel vm);
        ScheduleViewModel GetAll();
    }
}