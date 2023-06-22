using Cash.Core.Models;

namespace Cash.Repository.Interfaces
{
    public interface IAccountRepository : IModelRepository<Account>
    {
        public Task<List<Account>> GetAccountsWithBanksByUserAsync(int userId);
    }
}
