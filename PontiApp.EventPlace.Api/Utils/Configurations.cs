using Microsoft.Extensions.DependencyInjection;
using PontiApp.AuthService;
using PontiApp.EventEvent.Services.EventCategoryServices;
using PontiApp.EventPlace.Services.CategoryServices;
using PontiApp.EventPlace.Services.EventServices;
using PontiApp.EventPlace.Services.PlaceCategoryServices;
using PontiApp.EventPlace.Services.WeekDayServices;
using PontiApp.GraphAPICalls;
using PontiApp.Images.Repository;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.MessageSender;
using PontiApp.Models.Entities.AuthEntities;
using PontiApp.Models.Entities;
using PontiApp.Models;
using PontiApp.PlacePlace.Services.PlaceServices;
using PontiApp.Ponti.Repository.BaseRepository;
using PontiApp.Ponti.Repository.PontiRepository.EventRepository;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using PontiApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using PontiApp.Mappings;

namespace PontiApp.EventPlace.Api.Utils
{
    public static class Configurations
    {
        public static IServiceCollection AddEventPlaceRegistration(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IPlaceCategoryService, PlaceCategoryService>();
            services.AddTransient<IEventCategoryService, EventCategoryService>();
            services.AddTransient<IWeekDayService, WeekDayService>();
            services.AddTransient<BaseRepository<UserEntity>>();
            services.AddTransient<BaseRepository<CategoryEntity>>();
            services.AddTransient<BaseRepository<PlaceCategory>>();
            services.AddTransient<BaseRepository<EventCategory>>();
            services.AddTransient<BaseRepository<WeekEntity>>();
            services.AddTransient<EventRepository>();
            services.AddTransient<PlaceRepository>();
            services.AddTransient<EventDTOValidator>();
            services.AddTransient<PlaceDTOValidator>();
            services.AddSingleton<ConnectionFactory>();
            services.AddSingleton<MessagingService>();
            services.AddTransient<IJwtProcessor, JwtProcessor>();
            services.AddSingleton<JwtConfig>();
            services.AddTransient<IFbClient, FbClient>();
            services.AddHttpClient();
            services.AddSingleton(_ => new MongoClient(Configuration.GetConnectionString("MongoDB")));
            services.AddTransient<IMongoService, MongoService>();
            services.AddTransient<IMongoRepository, MongoRepository>();
            services.AddTransient<MessagingService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DbConnection"));
            });
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(UserMapper));
            services.AddAutoMapper(typeof(EventMapper));
            services.AddAutoMapper(typeof(PlaceMapper));
            services.AddAutoMapper(typeof(CategoryMapper));
            services.AddAutoMapper(typeof(WeekDayMapper));
            services.AddAutoMapper(typeof(ReviewMapper));
            return services;
        }
    }
}
