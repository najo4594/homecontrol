using HomeControl.DataAccess;
using HomeControl.Service.HttpClient;
using HomeControl.Service.HueApi;
using HomeControl.Service.Services;
using HomeControl.Service.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeControl.Web
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
			services.AddControllersWithViews();

			services.AddEntityFrameworkSqlServer()
				.AddDbContext<HomeControlContext>(
					(serviceProvider, options) =>
						options.UseSqlServer(Configuration.GetConnectionString("HomeControl"))
							.UseInternalServiceProvider(serviceProvider));
			
			// services.AddDbContext<HomeControlContext>(
			// 	options => options.UseSqlServer(Configuration.GetConnectionString(("HomeControl"))));

			services.AddSingleton<IHueApi, HueApi>();
			
			services.AddTransient<IHomeControlRepository, HomeControlRepository>();
			services.AddTransient<IHttpClient, HttpClient>();
			services.AddTransient<ILightService, LightService>();
			
			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");

				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseRouting();

			app.UseEndpoints(
				endpoints =>
				{
					endpoints.MapControllerRoute(
						"default",
						"{controller}/{action=Index}/{id?}");
				});

			app.UseSpa(
				spa =>
				{
					spa.Options.SourcePath = "ClientApp";

					if (env.IsDevelopment())
					{
						spa.UseReactDevelopmentServer("start");
					}
				});
		}
	}
}