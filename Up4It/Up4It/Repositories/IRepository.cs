using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Up4It.Repositories
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> identifier);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<T> AddAsync(T item);
    }
}
