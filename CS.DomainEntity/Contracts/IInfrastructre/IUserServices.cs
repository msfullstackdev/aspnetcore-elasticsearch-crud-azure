using CS.DomainEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DomainEntity.Contracts.IInfrastructre
{
    public interface IUserServices
    {
       Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task AddorUpdateAsync(User user);
        Task DeleteAsync(string id);

    }
}
