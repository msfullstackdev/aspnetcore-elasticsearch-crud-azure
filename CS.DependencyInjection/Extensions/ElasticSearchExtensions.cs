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
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex).DefaultTypeName("_doc");

            settings.EnableHttpCompression();
            settings.BasicAuthentication("elastic", "1aA$5425963*");

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
