using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;

namespace clinic.data.Repositories
{
    public sealed class TimeSlotRepository : Repository<TimeSlot>, ITimeSlotRepository
    {
        public TimeSlotRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<TimeSlot> GetTimeSlot()
        {
            return _context.TimeSlots;
        }

    }
}