using Microsoft.Extensions.Localization;
using SaveTheCookTower.Application.ApplicationServices;
using SaveTheCookTower.Application.ViewModels.relatorios;
using SaveTheCookTower.Application.XUnitTests.mocks;
using SaveTheCookTower.CrossCutting.Utils;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace SaveTheCookTower.Application.XUnitTests
{
	public class MockLocalizer<T> : IStringLocalizer<T>
	{
		public LocalizedString this[string name]
		{
			get
			{
				return new LocalizedString(name, name);
			}
		}

		public LocalizedString this[string name, params object[] arguments]
		{
			get
			{
				return new LocalizedString(name, string.Format(name, arguments));
				throw new NotImplementedException();
			}
		}

		public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
		{
			throw new NotImplementedException();
		}

		public IStringLocalizer WithCulture(CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public class CardapioAppReportServiceTest
	{
		private readonly IStringLocalizer<SharedResource> _localizer;

		private readonly IServiceBase<Cardapio> _service;
		private readonly IServiceBase<ItemCardapio> _itemService;
		private readonly IServiceBase<ItemCardapioReceita> _itemReceitaService;
		private readonly IServiceBase<Receita> _receitaService;
		private readonly IServiceBase<ItemListaIngredientes> _ingredientesService;

		private readonly CardapioAppReportService _appReportService;

		public CardapioAppReportServiceTest()
		{
			_localizer = new MockLocalizer<SharedResource>();
			_service = new MockServiceBase<Cardapio>();
			_itemService = new MockServiceBase<ItemCardapio>();
			_itemReceitaService = new MockServiceBase<ItemCardapioReceita>();
			_receitaService = new MockServiceBase<Receita>();
			_ingredientesService = new MockServiceBase<ItemListaIngredientes>();

			_appReportService = new CardapioAppReportService(_localizer, _service, _itemService,
			   _itemReceitaService, _receitaService, _ingredientesService);
		}


		private Cardapio AdicionarCardapio(Guid id, string nome)
		{
			var c = new Cardapio
			{
				Id = id,
				Nome = nome
			};
			(_service as MockServiceBase<Cardapio>).Model.Add(c);
			return c;
		}

		private Receita AdicionarReceita(Guid id, string nome, int porcoes,
			List<ItemListaIngredientes> ingredientes)
		{
			var r = new Receita
			{
				Id = id,
				Nome = nome,
				RendimentoPorcoes = porcoes,
			};

			ingredientes.ForEach(a => r.Ingredientes.Add(a));
			(_receitaService as MockServiceBase<Receita>).Model.Add(r);

			return r;
		}

		private static void Assert_SemIntervalosDefinidos(CardapioReportResultViewModel result)
		{
			Assert.Equal("Intervalo de semanas", result.CabecalhoDoRelatorio[1].NomeCampo);
			Assert.Equal("Nenhum intervalo selecionado", result.CabecalhoDoRelatorio[1].ValorCampo);

			Assert.Equal("Intervalo de itens", result.CabecalhoDoRelatorio[2].NomeCampo);
			Assert.Equal("Nenhum intervalo selecionado", result.CabecalhoDoRelatorio[2].ValorCampo);
		}

		private CardapioReportResultViewModel Execute(Guid cardapioId)
		{
			var relNome = "Lista de Ingredientes";

			var param = new CardapioReportParamsViewModel();

			param.CardapioId = cardapioId;

			param.Titulo = relNome;
			param.Subtitulo = _localizer["Por categoria, totalizando todas as receitas"].Value;

			var result = _appReportService.Execute(param);
			return result;
		}


		private static Categoria AdicionarCategoria(string nome, Categoria categoriaPai)
		{
			return new Categoria
			{
				Id = Guid.NewGuid(),
				Nome = nome,
				CategoriaPai = categoriaPai
			};
		}

		private ItemCardapioReceita AdicionarItemCardapioReceita(Receita receita, ItemCardapio itemCardapio)
		{
			var icr = new ItemCardapioReceita
			{
				Id = Guid.NewGuid(),
				ReceitaId = receita.Id,
				Receita = receita,
				ItemCardapioId = itemCardapio.Id,
				ItemCardapio = itemCardapio
			};
			(_itemReceitaService as MockServiceBase<ItemCardapioReceita>).Model.Add(icr);

			itemCardapio.ItensCardapioReceita.Add(icr);
			return icr;
		}

		private ItemCardapio AdicionarItemCardapio(int porcoes, Guid cardapioId, int semana, int diaDaSemana)
		{
			var ic = new ItemCardapio
			{
				Porcoes = porcoes,
				CardapioId = cardapioId,
				Semana = semana,
				DiaDaSemana = diaDaSemana,
			};
			(_itemService as MockServiceBase<ItemCardapio>).Model.Add(ic);
			return ic;
		}

		private ItemListaIngredientes AdicionarItemListaIngredientes(
			UnidadeMedida unidadeMedida, Ingrediente i, Guid receitaId, string nomeNovoItemIngrediente, Guid idNovoItemIngrediente, double qtd)
		{
			var ili = new ItemListaIngredientes
			{
				Id = idNovoItemIngrediente,
				Ingrediente = i,
				IngredienteId = i.Id,
				Nome = nomeNovoItemIngrediente,
				Quantidade = qtd,
				UnidadeMedidaId = unidadeMedida.Id,
				UnidadeMedida = unidadeMedida,
				ReceitaId = receitaId
			};
			(_ingredientesService as MockServiceBase<ItemListaIngredientes>).Model.Add(ili);
			return ili;
		}

		private static Ingrediente AdicionarIngrediente(Guid idNovoIngrediente, string nomeNovoIngrediente, Categoria catIng)
		{
			return new Ingrediente
			{
				Id = idNovoIngrediente,
				Nome = nomeNovoIngrediente,
				CategoriaId = catIng.Id,
				Categoria = catIng
			};
		}

		private static void Asssert_RegistrosDados(CardapioReportResultViewModel result, int indiceDados, int indiceRegistro, int numeroItem, string nomeIng, double quantidade, string nomeUnidade)
		{
			var valorEsperado = $"\"item={numeroItem}\",\"ing={nomeIng}\",\"count={quantidade}\",\"unit={nomeUnidade}\"";
			Assert.Equal(valorEsperado, result.Dados[indiceDados].Registros.CommaTextRegisters[indiceRegistro]);
		}

		private static void Assert_RodapeDados(CardapioReportResultViewModel result, int indiceDados, int indiceCab, string nomeEsperado, object valorEsperado)
		{
			Assert.Equal(nomeEsperado, result.Dados[indiceDados].RodapeDoGrupo[indiceCab].NomeCampo);
			Assert.Equal(valorEsperado, result.Dados[indiceDados].RodapeDoGrupo[indiceCab].ValorCampo);
		}

		private static void Assert_CabDados(CardapioReportResultViewModel result, int indiceDados, int indiceCab, string nomeEsperado, string valorEsperado)
		{
			Assert.Equal(nomeEsperado, result.Dados[indiceDados].CabecalhoDoGrupo[indiceCab].NomeCampo);
			Assert.Equal(valorEsperado, result.Dados[indiceDados].CabecalhoDoGrupo[indiceCab].ValorCampo);
		}


		[Fact]
		public void TestExecute_Sem_Dados()
		{
			Guid id = Guid.NewGuid();

			CardapioReportResultViewModel result = Execute(id);

			Assert.Equal("Cardápio", result.CabecalhoDoRelatorio[0].NomeCampo);
			Assert.Equal("Nenhum cardápio definido", result.CabecalhoDoRelatorio[0].ValorCampo);

			Assert_SemIntervalosDefinidos(result);

			Assert.Equal(0, result.Dados.Count);
		}


		[Fact]
		public void TestExecute_Apenas_Receita()
		{
			Guid id = Guid.NewGuid();

			AdicionarCardapio(id, "Cardapio teste sem ingredientes");

			CardapioReportResultViewModel result = Execute(id);

			Assert.Equal("Cardápio", result.CabecalhoDoRelatorio[0].NomeCampo);
			Assert.Equal("Cardapio teste sem ingredientes", result.CabecalhoDoRelatorio[0].ValorCampo);

			Assert_SemIntervalosDefinidos(result);

			Assert.Equal(0, result.Dados.Count);
		}


		[Theory]
		[InlineData(1, 1, 1, 10.0)]
		[InlineData(2, 1, 1, 20.0)]
		[InlineData(4, 1, 1, 40.0)]
		[InlineData(1, 1, 7, 70.0)]
		[InlineData(1, 4, 7, 280.0)]
		public void TestExecute_Somando_1_Ing_n_Semanas_Proporcao_Quantidade(int porcoes, int semanas, int diasdaSemana, double qtdEsperada)
		{
			Guid id = Guid.NewGuid();

			var unidadeMedida = new UnidadeMedida
			{
				Id = Guid.NewGuid(),
				Nome = "Kilograma"
			};

			var c = AdicionarCardapio(id, $"Cardapio teste 1 ing {semanas} semana(s), {diasdaSemana} dias (por semana)");

			var catIng = AdicionarCategoria("Ingredientes", AdicionarCategoria("Cat pai", null));

			Ingrediente i = AdicionarIngrediente(Guid.NewGuid(), "ing. único", catIng);

			var receitaId = Guid.NewGuid();

			ItemListaIngredientes ili = AdicionarItemListaIngredientes(unidadeMedida, i, receitaId,
				"20 kilograma de ing. único", Guid.NewGuid(), 20.0);

			var r = AdicionarReceita(receitaId, "receita única", 2, new List<ItemListaIngredientes>()
				{ ili });
			ili.Receita = r;

			for(int semana = 1; semana <= semanas; semana++)
				for (int diaDaSemana = 0; diaDaSemana < diasdaSemana; diaDaSemana++)
				{
					ItemCardapio ic = AdicionarItemCardapio(porcoes, cardapioId: id, semana, diaDaSemana);
					AdicionarItemCardapioReceita(r, ic);
					c.Itens.Add(ic);
				}

			CardapioReportResultViewModel result = Execute(id);

			Assert.Equal("Cardápio", result.CabecalhoDoRelatorio[0].NomeCampo);
			Assert.Equal(c.Nome, result.CabecalhoDoRelatorio[0].ValorCampo);

			Assert_SemIntervalosDefinidos(result);

			Assert.Equal(1, result.Dados.Count);

			Assert.Equal(1, result.Dados[0].CabecalhoDoGrupo.Count);

			Assert_CabDados(result, 0, 0, "", "Cat pai -> Ingredientes");
			Assert_RodapeDados(result, 0, 0, "Contador", "1");

			Assert.Equal(1, result.Dados[0].Registros.CommaTextRegisters.Count);

			Asssert_RegistrosDados(result, indiceDados: 0, indiceRegistro: 0, numeroItem: 1,
				"ing. único", quantidade: qtdEsperada, "Kilograma");
		}



	}
}
