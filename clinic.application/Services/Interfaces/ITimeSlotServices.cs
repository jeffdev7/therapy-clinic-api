using clinic.CrossCutting.Dto;

namespace clinic.application.Services.Interfaces
{
    public interface ITimeSlotServices : IDisposable
    {
        Task<TimeSlotViewModel> AddTimeSlot(TimeSlotViewModel vm);
        IEnumerable<TimeSlotViewModel> GetTimeSlot();
        Task<TimeSlotViewModel> Update(TimeSlotViewModel vm);
        IEnumerable<TimeSlotViewModel> GetAvailableTimeSlots();
        IQueryable<TimeSlotViewModel> GetAll();
    }
}