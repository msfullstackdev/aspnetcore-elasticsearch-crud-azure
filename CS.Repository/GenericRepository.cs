using CS.DomainEntity.Contracts.IRepository;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IElasticClient _client = null;
        public GenericRepository(IElasticClient elasticClient)
        {
            _client = elasticClient;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
                var res = await _client.SearchAsync<T>(s => s.From(0).Size(1000).MatchAll());
                return res.Documents;
           
            
        } 

        public async Task<T> GetByIdAsync(string id)
        {
           
            var res =await _client.GetAsync<T>(new DocumentPath<T>(id));

            return res.Source;
        }

        public async Task AddOrUpdateAsync(string id,T obj)
        {
          var res=  await _client.IndexAsync(obj,i=>i.Id(id));
        }

        public async Task DeleteAsync(string id)
        {
           await _client.DeleteAsync(new DocumentPath<T>(id));
        }
    }
}
