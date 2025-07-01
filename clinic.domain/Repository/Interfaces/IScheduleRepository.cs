using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        IQueryable<Schedule> GetSchedule();
    }
}