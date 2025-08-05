using clinic.CrossCutting.Dto;
using FluentValidation.Results;

namespace clinic.application.Services.Interfaces
{
    public interface ITimeSlotService : IDisposable
    {
        ValidationResult AddTimeSlot(TimeSlotViewModel vm);
        IEnumerable<TimeSlotViewModel> GetTimeSlot();
        IEnumerable<TimeSlotViewModel> GetAvailableTimeSlots();
        IQueryable<TimeSlotViewModel> GetAll();
        Task<bool> Remove(Guid id);
        TimeSlotViewModel GetById(Guid id);
        IQueryable<TimeSlotViewModel> GetAllByUserId(string userId);
    }
}