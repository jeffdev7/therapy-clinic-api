using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<DateTime> GetStartTimeRange(string userId)
        {
            return _context.TimeSlots.Where(u => u.UserId == userId)
               .Select(_ => _.Start);
        }
        public TimeSlot GetTimeSlotById(Guid id)
        {
            var time = _context.TimeSlots.Where(p => p.Id == id).SingleOrDefault();
            return time!;
        }
        public async Task RemoveTimeSlot(TimeSlot time)
        {
            _context.TimeSlots.Remove(time);
            await _context.SaveChangesAsync();
        }
        public EntityState UpdateProperty(TimeSlot time)
        {
            var x = _context.Entry(time).State = EntityState.Modified;
            return x!;
        }

    }
}