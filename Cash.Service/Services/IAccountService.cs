using Cash.Core.Models;

namespace Cash.Service.Services
{
    public interface IAccountService : IRepositoryService<Account>
    {
        public Task<List<Account>> GetAccountsWithBanksByUserAsync(int userId);
    }
}
