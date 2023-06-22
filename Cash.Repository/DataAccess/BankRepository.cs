using Cash.Core.Models;
using Cash.Repository.Interfaces;

namespace Cash.Repository.DataAccess
{
    public class BankRepository : ModelRepository<Bank>, IBankRepository
    {
        public BankRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
