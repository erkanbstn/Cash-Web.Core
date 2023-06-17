using Cash.Core.Models;
using Cash.Repository.DataAccess;
using Cash.Service.Services;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Cash.Service.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Sign In User With Claims

        public async Task<User> SignInAsync(User user)
        {
            return await _userRepository.SignInAsync(user);
        }

        // Sign In User With Claims

        public async Task<ClaimsPrincipal> SignInWithClaimAsync(User user)
        {
            var signedUser = await SignInAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, signedUser.UserName) };
            var userIdentity = new ClaimsIdentity(claims, "SignIn");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            //HttpContext.Session.SetString("UserMail", x.WriterMail);
            return claimsPrincipal;
        }
        public async Task ChangeStatusAllAsync(List<User> t)
        {
            await _userRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(User t)
        {
            await _userRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<User> t)
        {
            await _userRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(User t)
        {
            await _userRepository.DeleteAsync(t);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(User t)
        {
            await _userRepository.InsertAsync(t);
        }

        public async Task<List<User>> ToListAsync()
        {
            return await _userRepository.ToListAsync();
        }

        public async Task<List<User>> ToListByFilterAsync(Expression<Func<User, bool>> filter)
        {
            return await _userRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(User t)
        {
            await _userRepository.UpdateAsync(t);
        }

        // Find User by UserName

        public async Task<User> FindByUserNameAsync(string userName)
        {
            return await _userRepository.FindByUserNameAsync(userName);
        }
    }
}
