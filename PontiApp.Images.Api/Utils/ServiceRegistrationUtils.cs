using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PontiApp.Images.Repository;
using System.Configuration;
using PontiApp.Images.Services.Generic_Services;

namespace PontiApp.Images.Api.Utils
{
    public static class ServiceRegistrationUtils
    {
        public static IServiceCollection ConfigureImageServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddSingleton(_ => new MongoClient(config.GetConnectionString("MongoDB")));
            services.AddScoped<IMongoRepository, MongoRepository>();
            services.AddScoped<IMongoService, MongoService>();
            return services;
        }
    }
}
