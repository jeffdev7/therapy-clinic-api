using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;

namespace clinic.data.Repositories
{
    public sealed class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Schedule> GetSchedule()
        {
            return _context.Schedules;
        }

    }
}