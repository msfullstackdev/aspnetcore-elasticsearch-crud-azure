using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DomainEntity.Contracts.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void AddOrUpdate(string id,T obj);
        void Delete(string id);
    }
}
