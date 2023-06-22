using Cash.Core.Models;
using Cash.Repository.Interfaces;
using Cash.Service.Services;
using System.Linq.Expressions;

namespace Cash.Service.Managers
{
    public class ProcessManager : IProcessService
    {
        private readonly IProcessRepository _ProcessRepository;

        public ProcessManager(IProcessRepository ProcessRepository)
        {
            _ProcessRepository = ProcessRepository;
        }

        public async Task ChangeStatusAllAsync(List<Process> t)
        {
            await _ProcessRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Process t)
        {
            await _ProcessRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Process> t)
        {
            await _ProcessRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Process t)
        {
            await _ProcessRepository.DeleteAsync(t);
        }

        public async Task<Process> GetByIdAsync(int id)
        {
            return await _ProcessRepository.GetByIdAsync(id);
        }

        public async Task<List<Process>> GetListWithAccountAsync(int accountId)
        {
            return await _ProcessRepository.GetListWithAccountAsync(accountId);
        }

        public async Task<List<Process>> GetListWithAccountByReceiverAsync(int userId)
        {
            return await _ProcessRepository.GetListWithAccountByReceiverAsync(userId);
        }

        public async Task<List<Process>> GetListWithAccountBySenderAsync(int userId)
        {
            return await _ProcessRepository.GetListWithAccountBySenderAsync(userId);
        }

        public async Task InsertAsync(Process t)
        {
            await _ProcessRepository.InsertAsync(t);
        }

        public async Task<List<Process>> ToListAsync()
        {
            return await _ProcessRepository.ToListAsync();
        }

        public async Task<List<Process>> ToListByFilterAsync(Expression<Func<Process, bool>> filter)
        {
            return await _ProcessRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Process t)
        {
            await _ProcessRepository.UpdateAsync(t);
        }
    }
}
