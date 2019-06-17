using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DomainEntity.Contracts.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddOrUpdateAsync(string id,T obj);
        Task DeleteAsync(string id);
    }
}
