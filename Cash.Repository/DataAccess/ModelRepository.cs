using Cash.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cash.Repository.DataAccess
{
    public class ModelRepository<T> : IModelRepository<T> where T : class
    {
        // Context, DbSet Instance

        private readonly AppDbContext _appDbContext;
        DbSet<T> _object;

        // Context DbSet Set Constructor 
        public ModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _object = _appDbContext.Set<T>();
        }

        // Change All Status Transactions

        public async Task ChangeStatusAllAsync(List<T> t)
        {
            _object.UpdateRange(t);
            await _appDbContext.SaveChangesAsync();
        }

        // Change Status Transactions

        public async Task ChangeStatusAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }

        // Delete All Transactions

        public async Task DeleteAllAsync(List<T> t)
        {
            _object.RemoveRange(t);
            await _appDbContext.SaveChangesAsync();
        }

        // Delete Transactions

        public async Task DeleteAsync(T t)
        {
            _object.Remove(t);
            await _appDbContext.SaveChangesAsync();
        }

        // Get by Id Transactions

        public async Task<T> GetByIdAsync(int id)
        {
            return await _object.FindAsync(id);
        }

        // Insert Transactions

        public async Task InsertAsync(T t)
        {
            await _object.AddAsync(t);
            await _appDbContext.SaveChangesAsync();

        }

        // List Transactions

        public async Task<List<T>> ToListAsync()
        {
            return await _object.ToListAsync();
        }

        // List by Filter Transactions

        public async Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _object.Where(filter).ToListAsync();
        }

        // Update Transactions

        public async Task UpdateAsync(T t)
        {
            _object.Update(t);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
