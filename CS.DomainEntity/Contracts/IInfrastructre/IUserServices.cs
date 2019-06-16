using CS.DomainEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DomainEntity.Contracts.IInfrastructre
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll();
        User GetById(string id);
        void AddorUpdate(User user);
        void Delete(string id);

    }
}
