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
        public static IServiceCollection ConfigureImageServices(this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\USER\source\repos\PontiApp\PontiApp.Images.Api")
                .AddJsonFile("appsettings.json")
                .Build(); 
            services.AddSingleton(_ => new MongoClient(configuration.GetConnectionString("MongoDB")));
            services.AddScoped<IMongoRepository, MongoRepository>();
            services.AddScoped<IMongoService, MongoService>();
            return services;
        }
    }
}
