using Cash.Core.Models;
using Cash.Repository.Interfaces;

namespace Cash.Repository.DataAccess
{
    public interface IUserRepository : IModelRepository<User>
    {
        // Sign In User

        Task<User> SignInAsync(User user);

        // Find User by UserName
        Task<User> FindByUserNameAsync(string userName);

    }
}
