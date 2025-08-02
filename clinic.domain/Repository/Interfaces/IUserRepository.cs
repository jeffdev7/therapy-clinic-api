using clinic.domain.Entities;

namespace clinic.domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetAllUsers();
    }
}