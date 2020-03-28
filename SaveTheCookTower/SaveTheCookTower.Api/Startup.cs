using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SaveTheCookTower.Application.Mapping;
using SaveTheCookTower.CrossCuttingIoC;
using AutoMapper;
using SaveTheCookTower.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SaveTheCookTower.Api
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
			services.AddControllers()
			//adiciona conf. para tirar ref. circular na serialzaição
			.AddNewtonsoftJson(opt =>
			  opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			// minha injeção de depedencia
			RegisterIoC.Register(services);

			// config. o automapper
			services.AddAutoMapper(typeof(AutoMappingDomainToViewModel));
			services.AddAutoMapper(typeof(AutoMappingViewModelToDomain));

			// config do Context (EF)
			services.AddDbContext<SaveTheCookTowerContext>(opions => opions.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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
