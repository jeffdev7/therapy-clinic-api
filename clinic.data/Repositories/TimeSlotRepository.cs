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
        public (IQueryable<TimeSlot> T1, IQueryable<TimeSlot> T2) GetStartAndEndTime(DateTime dt1, DateTime dt2)
        {
            var start = _context.TimeSlots.Where(_ => _.Start == dt1);
            var end = _context.TimeSlots.Where(_ => _.End == dt2);

            return (start, end);
        }

    }
}