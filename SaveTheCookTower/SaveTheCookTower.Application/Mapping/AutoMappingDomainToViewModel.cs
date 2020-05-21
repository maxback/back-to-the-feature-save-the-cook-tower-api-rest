using AutoMapper;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.Mapping
{
	public class AutoMappingDomainToViewModel : Profile
	{
		public AutoMappingDomainToViewModel()
		{
			CreateMap<AvaliacaoDoUsuario, AvaliacaoDoUsuarioViewModel>();
			CreateMap<Categoria, CategoriaViewModel>();
			CreateMap<EquivalenciaEntreUnidadesDeMedida, EquivalenciaEntreUnidadesDeMedidaViewModel>();
			CreateMap<EtapaDePreparo, EtapaDePreparoViewModel>();
			CreateMap<FontePropriedadeIntelectual, FontePropriedadeIntelectualViewModel>();
			CreateMap<InformacaoNutricional, InformacaoNutricionalViewModel>();
			CreateMap<Ingrediente, IngredienteViewModel>();
			CreateMap<ItemListaIngredientes, ItemListaIngredientesViewModel>();
			CreateMap<Receita, ReceitaViewModel>();
			CreateMap<UnidadeMedida, UnidadeMedidaViewModel>();
			CreateMap<Usuario, UsuarioViewModel>();

			CreateMap<Cardapio, CardapioViewModel>();
			CreateMap<ItemCardapio, ItemCardapioViewModel>();
			CreateMap<ItemCardapioReceita, ItemCardapioReceitaViewModel>();
		}
	}
}
