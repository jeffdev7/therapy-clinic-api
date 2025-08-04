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

        public (IQueryable<TimeSlot> T1, IQueryable<TimeSlot> T2) GetStartAndEndTime(DateTime dt1, DateTime dt2, string userId)
        {
            var start = _context.TimeSlots.Where(_ => _.Start == dt1 && _.UserId == userId);
            var end = _context.TimeSlots.Where(_ => _.End == dt2 && _.UserId == userId);

            return (start, end);
        }

    }
}