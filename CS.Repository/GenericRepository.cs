using CS.DomainEntity.Contracts.IRepository;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CS.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IElasticClient _client = null;
        private readonly IDistributedCache _cache = null;


        public GenericRepository(IElasticClient elasticClient, IDistributedCache distributedCache)
        {
            _client = elasticClient;
            _cache = distributedCache;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var res = await _client.SearchAsync<T>(s => s.From(0).Size(1000).MatchAll());
            return res.Documents;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            T res = null;

            res = await ReadFromCache(id);

            if (res == null)
            {
                var dataFromDB = await _client.GetAsync<T>(new DocumentPath<T>(id));

                res = dataFromDB.Source;

                await SetToCache(id, dataFromDB.Source);
            }

            return res;
        }

        public async Task AddOrUpdateAsync(string id, T obj)
        {
            var res = await _client.IndexAsync(obj, i => i.Id(id));

            var cache = await _client.GetAsync<T>(new DocumentPath<T>(id));

            await SetToCache(id, cache.Source);
        }

        public async Task DeleteAsync(string id)
        {
            await _client.DeleteAsync(new DocumentPath<T>(id));
            await _cache.RemoveAsync(id);
        }

        private async Task SetToCache(string key, T value)
        {
            var options = new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) };

            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value),options);
        }

        private async Task<T> ReadFromCache(string key)
        {
            T cachedValue = null;

            string resFromCache = await _cache.GetStringAsync(key);

            if (!string.IsNullOrEmpty(resFromCache))
            {
                cachedValue = JsonConvert.DeserializeObject<T>(resFromCache);
            }

            return cachedValue;
        }

    }
}
