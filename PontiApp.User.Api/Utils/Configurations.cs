using PontiApp.AuthService;
using PontiApp.Data.DbContexts;
using PontiApp.GraphAPICalls;
using PontiApp.Images.Repository;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Mappings;
using PontiApp.MessageSender;
using PontiApp.Models.Entities.AuthEntities;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using PontiApp.User.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace PontiApp.User.Api.Utils
{
    public static class Configurations
    {
        public static IServiceCollection AddUserServiceRegistration(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<BaseRepository<UserEntity>>();
            services.AddControllers();
            services.AddSingleton<ConnectionFactory>();
            services.AddSingleton<MessagingService>();
            services.AddTransient<IJwtProcessor, JwtProcessor>();
            services.AddSingleton<JwtConfig>();
            services.AddTransient<IFbClient, FbClient>();
            services.AddHttpClient();
            services.AddTransient(_ => new MongoClient(Configuration.GetConnectionString("MongoDb")));
            services.AddTransient<IMongoService, MongoService>();
            services.AddTransient<IMongoRepository, MongoRepository>();
            services.AddTransient<MessagingService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DbConnection"));
            });

            services.AddAutoMapper(typeof(UserMapper));
            return services;
        }
    }
}
