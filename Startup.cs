using System;
using GarantsService.Context;
using GarantsService.Helpers;
using GarantsService.Interfaces;
using GarantsService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GarantsService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(dbContextOptions => 
                dbContextOptions
                    .UseMySql(Configuration.GetSection("ConnectionStrings").GetSection("Default").Value)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;

            services.AddScoped<IRequestDeniedService, RequestDeniedService>();
            services.AddScoped<IGetReferencesService, GetReferencesService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IGetNameByBinService, GetNameByBinService>();
            services.AddScoped<IGetChecherService, GetChecherService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<JwtService>();
            services.AddSwaggerGen();
            
            
            /*services.AddSwaggerGen(swagger =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);
            });*/
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}