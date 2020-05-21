using Microsoft.Extensions.DependencyInjection;
using SaveTheCookTower.Data.Repositories.Base;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Services.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ApplicationServices;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using Microsoft.Extensions.Localization;

namespace SaveTheCookTower.CrossCuttingIoC
{
	public class RegisterIoC
	{
		public static void Register(IServiceCollection serviceCollection)
		{
			// AppServices
			serviceCollection.AddScoped<IAvaliacaoDoUsuarioAppService, AvaliacaoDoUsuarioAppService>();
			serviceCollection.AddScoped<ICategoriaAppService, CategoriaAppService>();
			serviceCollection.AddScoped<IEquivalenciaEntreUnidadesDeMedidaAppService, EquivalenciaEntreUnidadesDeMedidaAppService>();
			serviceCollection.AddScoped<IEtapaDePreparoAppService, EtapaDePreparoAppService>();
			serviceCollection.AddScoped<IFontePropriedadeIntelectualAppService, FontePropriedadeIntelectualAppService>();
			serviceCollection.AddScoped<IInformacaoNutricionalAppService, InformacaoNutricionalAppService>();
			serviceCollection.AddScoped<IIngredienteAppService, IngredienteAppService>();
			serviceCollection.AddScoped<IItemListaIngredientesAppService, ItemListaIngredientesAppService>();
			serviceCollection.AddScoped<IReceitaAppService, ReceitaAppService>();
			serviceCollection.AddScoped<IUnidadeMedidaAppService, UnidadeMedidaAppService>();
			serviceCollection.AddScoped<IUnidadeMedidaAppService, UnidadeMedidaAppService>();
			serviceCollection.AddScoped<IUsuarioAppService, UsuarioAppService>();
			serviceCollection.AddScoped<ICardapioAppService, CardapioAppService>();
			serviceCollection.AddScoped<IItemCardapioAppService, ItemCardapioAppService>();
			serviceCollection.AddScoped<IItemCardapioReceitaAppService, ItemCardapioReceitaAppService>();

			// AppReportService
			serviceCollection.AddScoped<ICardapioAppReportService, CardapioAppReportService>();

			//Services
			serviceCollection.AddScoped<IAppServiceBase<AvaliacaoDoUsuarioViewModel>, AvaliacaoDoUsuarioAppService>();
			serviceCollection.AddScoped<IAppServiceBase<CategoriaViewModel>, CategoriaAppService>();
			serviceCollection.AddScoped<IAppServiceBase<EquivalenciaEntreUnidadesDeMedidaViewModel>, EquivalenciaEntreUnidadesDeMedidaAppService>();
			serviceCollection.AddScoped<IAppServiceBase<EtapaDePreparoViewModel>, EtapaDePreparoAppService>();
			serviceCollection.AddScoped<IAppServiceBase<FontePropriedadeIntelectualViewModel>, FontePropriedadeIntelectualAppService>();
			serviceCollection.AddScoped<IAppServiceBase<InformacaoNutricionalViewModel>, InformacaoNutricionalAppService>();
			serviceCollection.AddScoped<IAppServiceBase<IngredienteViewModel>, IngredienteAppService>();
			serviceCollection.AddScoped<IAppServiceBase<ItemListaIngredientesViewModel>, ItemListaIngredientesAppService>();
			serviceCollection.AddScoped<IAppServiceBase<ReceitaViewModel>, ReceitaAppService>();
			serviceCollection.AddScoped<IAppServiceBase<UsuarioViewModel>, UsuarioAppService>();
			serviceCollection.AddScoped<IAppServiceBase<UnidadeMedidaViewModel>, UnidadeMedidaAppService>();
			serviceCollection.AddScoped<IAppServiceBase<CardapioViewModel>, CardapioAppService>();
			serviceCollection.AddScoped<IAppServiceBase<ItemCardapioViewModel>, ItemCardapioAppService>();
			serviceCollection.AddScoped<IAppServiceBase<ItemCardapioReceitaViewModel>, ItemCardapioReceitaAppService>();

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
			serviceCollection.AddScoped<IServiceBase<Cardapio>, ServiceBase<Cardapio>>();
			serviceCollection.AddScoped<IServiceBase<ItemCardapio>, ServiceBase<ItemCardapio>>();
			serviceCollection.AddScoped<IServiceBase<ItemCardapioReceita>, ServiceBase<ItemCardapioReceita>>();

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
			serviceCollection.AddScoped<IRepositoryBase<Cardapio>, RepositoryBase<Cardapio>>();
			serviceCollection.AddScoped<IRepositoryBase<ItemCardapio>, RepositoryBase<ItemCardapio>>();
			serviceCollection.AddScoped<IRepositoryBase<ItemCardapioReceita>, RepositoryBase<ItemCardapioReceita>>();

		}
	}
}
