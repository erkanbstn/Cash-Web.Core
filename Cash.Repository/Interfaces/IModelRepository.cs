using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cash.Repository.Interfaces
{
    public interface IModelRepository<T> where T : class
    {
        Task InsertAsync(T t);
        Task DeleteAsync(T t);
        Task DeleteAllAsync(List<T> t);
        Task ChangeStatusAsync(T t);
        Task ChangeStatusAllAsync(List<T> t);
        Task UpdateAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ToListAsync();
        Task<List<T>> ToListByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
