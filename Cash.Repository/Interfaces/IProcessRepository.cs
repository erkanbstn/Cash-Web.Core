using Cash.Core.Models;

namespace Cash.Repository.Interfaces
{
    public interface IProcessRepository : IModelRepository<Process>
    {
        public Task<List<Process>> GetListWithAccountByReceiverAsync(int userId);
        public Task<List<Process>> GetListWithAccountBySenderAsync(int userId);
    }
}
