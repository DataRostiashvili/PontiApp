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
            services.AddScoped<IFbClient, FbClient>();
            services.AddScoped<IJwtProcessor, JwtProcessor>();
            services.AddScoped<MessagingService>();
            services.AddScoped<ConnectionFactory>();
            services.AddHttpClient();
            services.AddSingleton<JwtConfig>();

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
