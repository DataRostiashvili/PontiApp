using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using PontiApp.Mappings;
using PontiApp.MessageSender;
using PontiApp.Models.Entities;
using PontiApp.Models.Entities.AuthEntities;
using PontiApp.Ponti.Repository.BaseRepository;
using PontiApp.User.Services;
using RabbitMQ.Client;
using MongoDB.Driver;
using PontiApp.Images.Repository;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace PontiApp.User.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PontiApp.User.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PontiApp.User.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
