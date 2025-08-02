using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace clinic.data.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }
        public IdentityRole GetUserRoleById(string userId)
        {
            var user = _context.UserRoles.Where(_ => _.UserId == userId).SingleOrDefault();
            var userRole = _context.Roles.Where(_ => _.Id == user!.RoleId).SingleOrDefault();
            return userRole!;
        }
    }
}