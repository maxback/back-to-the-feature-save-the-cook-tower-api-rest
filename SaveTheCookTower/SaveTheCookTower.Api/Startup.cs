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
using System;
using SaveTheCookTower.CrossCutting.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Options;

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

			//localizer
			services.AddLocalization(opts => {
				opts.ResourcesPath = "Resources"; 
			});

			//mapeia localizer para view (não vou usar mas...) e data annotation (isso é interessante)
			services.AddMvc()
				.AddViewLocalization(
					opts => { opts.ResourcesPath = "Resources"; } )
				.AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
				.AddDataAnnotationsLocalization();

			//configura cultura com base nas requisições
			services.Configure<RequestLocalizationOptions>(opts =>
			{
				//configuração das culturas suportadas (fazem localizer chavear entre os recursos de linguagens difernetes
				//adicionar culturas que serão suportadas
				var suportedCultures = new List<CultureInfo>
				{
					new CultureInfo("pt-BR"),
					new CultureInfo("en-US")
				};

				//*** para setar outracoisa pode-se passar na query ?culture=en-US ou setar o header Accept-Language = en-US
				opts.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
				// formatação de numeros, datas, etc.
				opts.SupportedCultures = suportedCultures;
				//string de UI (não uso mas...)
				opts.SupportedUICultures = suportedCultures;

			});

			//ver ativação da cultura pela requisição no método Configure()

			// minha injeção de depedencia
			RegisterIoC.Register(services);

			// config. o automapper
			services.AddAutoMapper(typeof(AutoMappingDomainToViewModel));
			services.AddAutoMapper(typeof(AutoMappingViewModelToDomain));

			// config do Context (EF)
			services.AddDbContext<SaveTheCookTowerContext>(opions => opions.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			// Configuração da autenticação
			ConfigureAuth(services);

			//configura doc. da api
			ConfigureSwagger(services);

		}

		private void ConfigureSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Save The Cook Tower API",
					Version = "1.0.0",
					License = new OpenApiLicense
					{
						Url = new Uri("https://swagger.io/docs/specification/api-general-info/e")
					},
					Description = "API para fornecimento de serviço de controle de receitas e dados de ingredientes.</br>",
					Contact = new OpenApiContact
					{
						Name = "Max Back",
						Email = "max.back@gmail.com",
						Url = new Uri("https://www.linkedin.com/in/max-back-37843627")
					}
				});

				var security = new Dictionary<string, IEnumerable<string>>
					{
						{"Bearer", new string[] { }},
					};

				config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header usando Bearer scheme. Exemplo: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				config.AddSecurityRequirement(new OpenApiSecurityRequirement { });


				// Para funcionar a leitura do .xml de documentação é preciso habilitar nas configurações do projeto:
				// https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				config.IncludeXmlComments(xmlPath);
			});
		}

		private void ConfigureAuth(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection("AppSettings");

			//AppSettings é uma calsse de helper que tem a propriedade que quero ler (SecretKeyJWT)
			services.Configure<AppSettings>(appSettingsSection);

			// configure jwt authentication
			var appSettings = appSettingsSection.Get<AppSettings>();
			var secretKeyJWT = Encoding.ASCII.GetBytes(appSettings.SecretKeyJWT);

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secretKeyJWT),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//Ativação da cultura pela requisição
			var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(options.Value);


			//app.UseHttpsRedirection();

			// global cors policy
			//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


			app.UseSwagger();
			app.UseSwaggerUI(config =>
			{
				config.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Save The Cook Tower V1");
				//para fazer o swagger vir na raiz da url:
				config.RoutePrefix = string.Empty;
			});
			
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
