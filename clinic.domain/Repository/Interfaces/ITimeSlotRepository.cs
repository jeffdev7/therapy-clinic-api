using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        IQueryable<TimeSlot> GetTimeSlot();
    }
}