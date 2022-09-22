using Biolerplate.Controllers.Converters;
using Boilerplate.Callouts.DealerCar.Services;
using Boilerplate.Callouts.UserSession.Services;
using Boilerplate.Callouts.DealerCar.Converters;
using Boilerplate.Callouts.UserSession.Converters;
using Boilerplate.Controllers.Converters;
using Boilerplate.Controllers.Handlers;
using Boilerplate.UI.Controllers.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using System;
using Boilerplate.Controllers.Validators;
using Boilerplate.Models.DealerCar;
using Boilerplate.Controllers.Requests;
using Boilerplate.Validators;

namespace Boilerplate
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
            services.AddControllers();

            services.AddScoped<IUserSessionHandler, UserSessionHandler>();
            services.AddScoped<IDealerCarHandler, DealerCarHandler>(); 
            services.AddScoped<IUserSessionControllerConverter, UserSessionControllerConverter>();
            services.AddScoped<IDealerCarControllerConverter, DealerCarControllerConverter>();
            services.AddScoped<IUserSessionCalloutConverter, UserSessionCalloutConverter>();
            services.AddScoped<IDealerCarCalloutConverter, DealerCarCalloutConverter>();
            services.AddScoped<IUserSessionCalloutService, UserSessionCalloutService>();
            services.AddScoped<IDealerCarCalloutService, DealerCarCalloutService>();

            services.AddScoped<IValidator<DealerInformationRequest>, DealerInformationRequestValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
               // Cannot use AllowCredentials() with a wildcard origin               
               .WithOrigins("http://localhost:8080")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());

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
