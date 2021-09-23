using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PontiApp.Images.Repository;
using PontiApp.Images.Services;
using PontiApp.Images.Services.EventService;
using PontiApp.Models.MongoSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.Images.Api.Utils
{
    public static class ServiceRegistrationUtils
    {
        public static IServiceCollection ConfigureImageServices(this IServiceCollection services)
        {
            services.AddSingleton(_ => new MongoClient("mongodb://127.0.0.1:27017"));
            services.AddSingleton(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddSingleton<IMongoEventService, MongoEventService>();
            services.AddSingleton<IMongoUserService, MongoUserService>();
            services.AddSingleton<IMongoUserService, MongoUserService>();
            return services;
        }
    }
}
