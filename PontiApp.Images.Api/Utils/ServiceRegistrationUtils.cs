using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PontiApp.Images.Repository;
using System.Configuration;
using PontiApp.Images.Services.Generic_Services;
using Microsoft.OpenApi.Models;
using PontiApp.Images.Api.RabbitBackgroundService;
using PontiApp.Images.Cache.Caching_service;
using PontiApp.Utilities;
using RabbitMQ.Client;

namespace PontiApp.Images.Api.Utils
{
    public static class ServiceRegistrationUtils
    {
        public static IServiceCollection AddImageServiceConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHostedService<ImageReceiverService>();
            services.AddScoped<IMongoService, MongoService>();
            services.AddSingleton<ConnectionFactory>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PontiApp.Images.Api", Version = "v1" });
            });
            services.AddCustomAuth();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });
            services.AddScoped<ICachingService, CachingService>();
            return services;
        }
    }
}
