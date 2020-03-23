using Microsoft.Extensions.DependencyInjection;
using SaveTheCookTower.Data.Repositories.Base;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Services.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.CrossCuttingIoC
{
	public class RegisterIoC
	{
		public static void Register(IServiceCollection serviceCollection)
		{
			// AppServices



			// services
			serviceCollection.AddScoped<IServiceBase<AvaliacaoDoUsuario>, ServiceBase<AvaliacaoDoUsuario>>();
			serviceCollection.AddScoped<IServiceBase<Categoria>, ServiceBase<Categoria>>();
			serviceCollection.AddScoped<IServiceBase<EquivalenciaEntreUnidadesDeMedida>, ServiceBase<EquivalenciaEntreUnidadesDeMedida>>();
			serviceCollection.AddScoped<IServiceBase<EtapaDePreparo>, ServiceBase<EtapaDePreparo>>();
			serviceCollection.AddScoped<IServiceBase<FontePropriedadeIntelectual>, ServiceBase<FontePropriedadeIntelectual>>();
			serviceCollection.AddScoped<IServiceBase<InformacaoNutricional>, ServiceBase<InformacaoNutricional>>();
			serviceCollection.AddScoped<IServiceBase<Ingrediente>, ServiceBase<Ingrediente>>();
			serviceCollection.AddScoped<IServiceBase<ItemListaIngredientes>, ServiceBase<ItemListaIngredientes>>();
			serviceCollection.AddScoped<IServiceBase<Receita>, ServiceBase<Receita>>();
			serviceCollection.AddScoped<IServiceBase<UnidadeMedida>, ServiceBase<UnidadeMedida>>();
			serviceCollection.AddScoped<IServiceBase<Usuario>, ServiceBase<Usuario>>();

			// repositories
			serviceCollection.AddScoped<IRepositoryBase<AvaliacaoDoUsuario>, RepositoryBase<AvaliacaoDoUsuario>> ();
			serviceCollection.AddScoped<IRepositoryBase<Categoria>, RepositoryBase<Categoria>>();
			serviceCollection.AddScoped<IRepositoryBase<EquivalenciaEntreUnidadesDeMedida>, RepositoryBase<EquivalenciaEntreUnidadesDeMedida>>();
			serviceCollection.AddScoped<IRepositoryBase<EtapaDePreparo>, RepositoryBase<EtapaDePreparo>>();
			serviceCollection.AddScoped<IRepositoryBase<FontePropriedadeIntelectual>, RepositoryBase<FontePropriedadeIntelectual>>();
			serviceCollection.AddScoped<IRepositoryBase<InformacaoNutricional>, RepositoryBase<InformacaoNutricional>>();
			serviceCollection.AddScoped<IRepositoryBase<Ingrediente>, RepositoryBase<Ingrediente>>();
			serviceCollection.AddScoped<IRepositoryBase<ItemListaIngredientes>, RepositoryBase<ItemListaIngredientes>>();
			serviceCollection.AddScoped<IRepositoryBase<Receita>, RepositoryBase<Receita>>();
			serviceCollection.AddScoped<IRepositoryBase<UnidadeMedida>, RepositoryBase<UnidadeMedida>>();
			serviceCollection.AddScoped<IRepositoryBase<Usuario>, RepositoryBase<Usuario>>();

		}
	}
}
