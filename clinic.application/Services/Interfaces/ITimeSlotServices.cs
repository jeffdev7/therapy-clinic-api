using clinic.CrossCutting.Dto;
using ErrorOr;
using FluentValidation.Results;

namespace clinic.application.Services.Interfaces
{
    public interface ITimeSlotServices : IDisposable
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