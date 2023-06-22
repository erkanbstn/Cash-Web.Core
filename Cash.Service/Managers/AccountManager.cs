using Cash.Core.Models;
using Cash.Repository.Interfaces;
using Cash.Service.Services;
using System.Linq.Expressions;

namespace Cash.Service.Managers
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly Random _random;
        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _random = new Random();
        }

        public async Task ChangeStatusAllAsync(List<Account> t)
        {
            await _accountRepository.ChangeStatusAllAsync(t);
        }

        public async Task ChangeStatusAsync(Account t)
        {
            await _accountRepository.ChangeStatusAsync(t);
        }

        public async Task DeleteAllAsync(List<Account> t)
        {
            await _accountRepository.DeleteAllAsync(t);
        }

        public async Task DeleteAsync(Account t)
        {
            await _accountRepository.DeleteAsync(t);
        }

        public async Task<Account> GetAccountsByNoAsync(string no)
        {
            return await _accountRepository.GetAccountsByNoAsync(no);
        }

        public async Task<List<Account>> GetAccountsWithBanksByUserAsync(int userId)
        {
            return await _accountRepository.GetAccountsWithBanksByUserAsync(userId);
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Account t)
        {
            t.No = $"{_random.Next(1000, 9999)}{_random.Next(1000, 9999)}{_random.Next(1000, 9999)}{_random.Next(1000, 9999)}";
            await _accountRepository.InsertAsync(t);
        }

        public async Task<List<Account>> ToListAsync()
        {
            return await _accountRepository.ToListAsync();
        }

        public async Task<List<Account>> ToListByFilterAsync(Expression<Func<Account, bool>> filter)
        {
            return await _accountRepository.ToListByFilterAsync(filter);
        }

        public async Task UpdateAsync(Account t)
        {
            await _accountRepository.UpdateAsync(t);
        }
    }
}
