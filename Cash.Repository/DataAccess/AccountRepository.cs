using Cash.Core.Models;
using Cash.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cash.Repository.DataAccess
{
    public class AccountRepository : ModelRepository<Account>, IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext) : base(appDbContext) => _appDbContext = appDbContext;
        public async Task<List<Account>> GetAccountsWithBanksByUserAsync(int userId) => await _appDbContext.Accounts.Where(x => x.UserId == userId).Include(x => x.Bank).ToListAsync();


    }
}
