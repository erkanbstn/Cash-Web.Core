using Cash.Core.Models;

namespace Cash.Repository.Interfaces
{
    public interface IUserRepository : IModelRepository<User>
    {
        // Sign In User

        Task<User> SignInAsync(User user);

        // Find User by UserName
        Task<User> FindByUserNameAsync(string userName);

    }
}
