using Cash.Core.Models;
using Cash.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cash.Repository.DataAccess
{
    public class ProcessRepository : ModelRepository<Process>, IProcessRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProcessRepository(AppDbContext appDbContext) : base(appDbContext) => _appDbContext = appDbContext;
        public async Task<List<Process>> GetListWithAccountAsync(int accountId) => await _appDbContext.Processes.Where(x => x.SenderId == accountId || x.ReceiverId == accountId).Include(x => x.SenderPrc).Include(x => x.ReceiverPrc).ThenInclude(c => c.User).ToListAsync();
        public async Task<List<Process>> GetListWithAccountByReceiverAsync(int userId) => await _appDbContext.Processes.Where(x => x.ReceiverId == userId).Include(x => x.SenderPrc).ThenInclude(x => x.User).ToListAsync();
        public async Task<List<Process>> GetListWithAccountBySenderAsync(int userId) => await _appDbContext.Processes.Where(x => x.SenderId == userId).Include(x => x.ReceiverPrc).ThenInclude(x => x.User).ToListAsync();
    }
}
