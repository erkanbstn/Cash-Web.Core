using Cash.Core.Models;
using System.Security.Claims;

namespace Cash.Service.Services
{
    public interface IUserService : IRepositoryService<User>
    {
        // Sign In User With Claims

        Task<ClaimsPrincipal> SignInWithClaimAsync(User user);

        // Sign In User

        Task<User> SignInAsync(User user);

        // Find User by UserName
        Task<User> FindByUserNameAsync(string userName);
    }
}
