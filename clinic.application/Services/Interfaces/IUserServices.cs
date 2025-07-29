using clinic.CrossCutting.Dto;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace clinic.application.Services.Interfaces
{
    public interface IUserServices : IDisposable
    {
        Task<IdentityResult> RegisterUser(RegisterViewModel register);
        Task<SignInResult> LogIn(LoginViewModel login);
        Task LogOut();
        string? GetUserId();
        string? GetUserRole();
        Task<List<string?>> GetAllRoles();
        Task<bool> GetCurrentUser(ClaimsPrincipal claimsIdentity);
    }
}
