using Cash.Core.Models;
using Cash.Repository.Interfaces;
using Cash.Service.Services;
using System.Linq.Expressions;

namespace Cash.Service.Managers
{
    public class BankManager : IBankService
    {
        private readonly IBankRepository _BankRepository;

        public BankManager(IBankRepository BankRepository)
        {
            _BankRepository = BankRepository;
        }

        public async Task ChangeStatusAllAsync(List<Bank> t)
        {
            await _BankRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Bank t)
        {
            await _BankRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Bank> t)
        {
            await _BankRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Bank t)
        {
            await _BankRepository.DeleteAsync(t);
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _BankRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Bank t)
        {
            await _BankRepository.InsertAsync(t);
        }

        public async Task<List<Bank>> ToListAsync()
        {
            return await _BankRepository.ToListAsync();
        }

        public async Task<List<Bank>> ToListByFilterAsync(Expression<Func<Bank, bool>> filter)
        {
            return await _BankRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Bank t)
        {
            await _BankRepository.UpdateAsync(t);
        }
    }
}
