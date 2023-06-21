using Cash.Core.Models;

namespace Cash.Service.Services
{
    public interface IProcessService : IRepositoryService<Process>
    {
        public Task<List<Process>> GetListWithAccountByReceiverAsync(int userId);
        public Task<List<Process>> GetListWithAccountBySenderAsync(int userId);
    }
}
