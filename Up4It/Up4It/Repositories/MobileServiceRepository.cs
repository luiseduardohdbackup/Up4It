using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Up4It.Repositories
{
    public abstract class MobileServiceRepository<T> : IRepository<T> where T : class, new()
    {
        private IMobileServiceClient _client;

        public MobileServiceRepository(IMobileServiceClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _client.GetTable<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _client.GetTable<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            await _client.GetTable<T>().UpdateAsync(item);

            return item;
        }

        public async Task DeleteAsync(T item)
        {
            _client.GetTable<T>().DeleteAsync(item);
        }

        public async Task<T> AddAsync(T item)
        {
            await _client.GetTable<T>().InsertAsync(item);

            return item;
        }

        public void Dispose()
        {
            if (_client != null)
                _client = null;

            return;
        }
    }
}
