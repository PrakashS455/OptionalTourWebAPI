using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptionalToursAPI.Api.Mapper;
using OptionalToursAPI.Api.Models;
using OptionalToursAPI.Application.Interfaces;
using OptionalToursAPI.Application.Services;
using OptionalToursAPI.Infrastructure.Context;
using OptionalToursAPI.Infrastructure.Interfaces;
using OptionalToursAPI.Infrastructure.Repositories;
using OptionalToursAPI.Common.Configuration;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OptionalToursAPI.Application.Attributes;

namespace OptionalToursAPI.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddMemoryCache();
			services.AddSingleton<IAppCache, AppCache>();
			services.Configure<CacheSettings>(Configuration.GetSection("CacheSettings"));
			services.Configure<FolderSettings>(Configuration.GetSection("FolderSettings"));
			services.AddScoped<CachingAttribute>();
			services.AddMvc().AddFluentValidation(fv => { });
			services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();
			services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
			services.Configure<WindwardReports>(Configuration.GetSection("WindwardReports"));
			services.AddScoped<IAvailableShipsService, AvailableShipsService>();
			services.AddScoped<IAvailableShipsRepository, AvailableShipsRepository>();
			services.AddScoped<IAvailableItinerariesService, AvailableItinerariesService>();
			services.AddScoped<IAvailableItinerariesRepository, AvailableItinerariesRepository>();
			services.AddScoped<IAvailablePriceAdjustmentService, AvailablePriceAdjustmentService>();
			services.AddScoped<IAvailablePriceAdjustmentRepository, AvailablePriceAdjustmentRepository>();
			services.AddScoped<IDataBaseManager, DatabaseManager>();
			services.AddAutoMapper(cfg => cfg.AddProfile<TemplateProfile>(), AppDomain.CurrentDomain.GetAssemblies());
			services.AddCors(options =>{options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
				app.UseExceptionHandler("/error");
				app.UseAuthentication();
            }
            else
            {
				app.UseDeveloperExceptionPage();
				app.UseHsts();
				app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();           
			app.UseRouting();
			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
			});
		}
    }
}
