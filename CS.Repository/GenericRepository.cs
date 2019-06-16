using CS.DomainEntity.Contracts.IRepository;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IElasticClient _client = null;
        public GenericRepository(IElasticClient elasticClient)
        {
            _client = elasticClient;
        }

        public IEnumerable<T> GetAll()
        {
            var res = _client.Search<T>();

            return res.Documents;
        }

        public T GetById(string id)
        {
           
            var res = _client.Get<T>(new DocumentPath<T>(id));

            return res.Source;
        }

        public void AddOrUpdate(string id,T obj)
        {
            var res = _client.Index(obj,i=>i.Id(id));
        }

        public void Delete(string id)
        {
            _client.Delete(new DocumentPath<T>(id));
        }
    }
}
