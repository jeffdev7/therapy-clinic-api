using clinic.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace clinic.domain.Repository.Interfaces
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        (IQueryable<TimeSlot> T1, IQueryable<TimeSlot> T2) GetStartAndEndTime(DateTime dt1, DateTime dt2, string userId);
        Task RemoveTimeSlot(TimeSlot time);
        TimeSlot GetTimeSlotById(Guid id);
        EntityState UpdateProperty(TimeSlot time);
    }
}