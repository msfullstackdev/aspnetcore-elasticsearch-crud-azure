using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DependencyInjection.Extensions
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ElasticSearch:Url"];
            var defaultIndex = configuration["ElasticSearch:Index"];

            var userName = configuration["ElasticSearch:UserName"];
            var password = configuration["ElasticSearch:Password"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex).DefaultTypeName("_doc");

            settings.EnableHttpCompression();

            settings.BasicAuthentication(userName,password);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
