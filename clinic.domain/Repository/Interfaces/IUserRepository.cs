using clinic.domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace clinic.domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetAllUsers();
        IdentityRole GetUserRoleById(string userId);
    }
}