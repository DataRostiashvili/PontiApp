using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PontiApp.Data.DbContexts;
using PontiApp.EventEvent.Services.EventCategoryServices;
using PontiApp.EventPlace.Services.CategoryServices;
using PontiApp.EventPlace.Services.EventServices;
using PontiApp.EventPlace.Services.PlaceCategoryServices;
using PontiApp.EventPlace.Services.WeekDayServices;
using PontiApp.Mappings;
using PontiApp.Models;
using PontiApp.Models.Entities;
using PontiApp.PlacePlace.Services.PlaceServices;
using PontiApp.Ponti.Repository.BaseRepository;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Ponti.Repository.PontiRepository.BaseRepository;
using PontiApp.Ponti.Repository.PontiRepository.EventRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Reflection;
using System;
using PontiApp.Utilities;
using System.IO;
using System.Reflection;
using System.Text;
using PontiApp.MessageSender;
using RabbitMQ.Client;
using PontiApp.AuthService;
using PontiApp.Models.Entities.AuthEntities;
using System.Net.Http;
using PontiApp.GraphAPICalls;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Images.Repository;
using MongoDB.Driver;
using PontiApp.EventPlace.Api.Utils;

namespace PontiApp.EventPlace.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PontiApp.EventPlace.Api", Version = "v1" });

            });

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddEventPlaceRegistration(Configuration);


            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddMappers();
            //services.AddCustomAuth();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlerMiddlware>();

            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PontiApp.Auth v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();




            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}