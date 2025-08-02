using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        IQueryable<TimeSlot> GetTimeSlot();
        (IQueryable<TimeSlot> T1, IQueryable<TimeSlot> T2) GetStartAndEndTime(DateTime dt1, DateTime dt2, string userId);
    }
}