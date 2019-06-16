using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DomainEntity.Contracts.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(string id);
    }
}
