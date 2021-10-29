using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PontiApp.Images.Api.RabbitBackgroundService;
using PontiApp.Images.Api.Utils;
using PontiApp.Images.Cache.Caching_service;
using PontiApp.Images.Repository;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Utilities;
using RabbitMQ.Client;
using System.Text;

namespace PontiApp.Images.Api
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {

            services.ConfigureImageServices(Configuration);
            services.AddHostedService<ImageReceiverService>();
            services.AddScoped<IMongoService,MongoService>();
            services.AddTransient<ConnectionFactory,ConnectionFactory>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",new OpenApiInfo { Title = "PontiApp.Images.Api",Version = "v1" });
            });
            services.AddCustomAuth(Configuration);
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Redis");
            });
            services.AddScoped<ICachingService,CachingService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
