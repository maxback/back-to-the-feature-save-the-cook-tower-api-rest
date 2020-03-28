using AutoMapper;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.Mapping
{
	public class AutoMappingViewModelToDomain : Profile
	{
		public AutoMappingViewModelToDomain()
		{
			CreateMap<AvaliacaoDoUsuarioViewModel, AvaliacaoDoUsuario>();
			CreateMap<CategoriaViewModel, Categoria>();
			CreateMap<EquivalenciaEntreUnidadesDeMedidaViewModel, EquivalenciaEntreUnidadesDeMedida>();
			CreateMap<EtapaDePreparoViewModel, EtapaDePreparo>();
			CreateMap<FontePropriedadeIntelectualViewModel, FontePropriedadeIntelectual>();
			CreateMap<InformacaoNutricionalViewModel, InformacaoNutricional>();
			CreateMap<IngredienteViewModel, Ingrediente>();
			CreateMap<ItemListaIngredientesViewModel, ItemListaIngredientes>();
			CreateMap<ReceitaViewModel, Receita>();
			CreateMap<UnidadeMedidaViewModel, UnidadeMedida>();
			CreateMap<UsuarioViewModel, Usuario>();
		}
	}
}
