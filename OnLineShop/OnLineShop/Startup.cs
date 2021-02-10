using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnLineShop.Core.Interfaces;
using OnLineShop.Error;
using OnLineShop.Extensions;
using OnLineShop.Helpers;
using OnLineShop.Infrastructure.Data;
using OnLineShop.Infrastructure.Identity;
using OnLineShop.Infrastructure.Services;
using OnLineShop.Middleware;
using StackExchange.Redis;

namespace OnLineShop
{
    public class Startup
    { private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            // Configuration = configuration;
           _config = config;
        }

       // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                 .AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<ITokenService, TokenService>();
           
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(x =>
             x.UseSqlServer(_config.GetConnectionString("IdentityConnection")));
            services.AddAplicationServices();
            services.AddSwaggerDocumentation();

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {

                var configuration = ConfigurationOptions.Parse(_config
                    .GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddIdentityServices(_config);
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolisy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44386");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();
            app.UseCors("CorsPolisy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerDocumentation();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
