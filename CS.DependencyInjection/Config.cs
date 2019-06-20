using CS.DependencyInjection.Extensions;
using CS.DomainEntity.Contracts.IInfrastructre;
using CS.DomainEntity.Contracts.IRepository;
using CS.Infrastructure;
using CS.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DependencyInjection
{
    public static class Config
    {
        public static IServiceCollection UpdateServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElasticsearch(configuration);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Connection"];
                options.InstanceName = configuration["Redis:InstanceName"];
            });

            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddSingleton<IUserServices, UserServices>();

            return services;
        }

    }
}
