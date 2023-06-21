using Cash.Core.Models;
using Cash.Repository.Interfaces;

namespace Cash.Repository.DataAccess
{
    public class AccountRepository : ModelRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
