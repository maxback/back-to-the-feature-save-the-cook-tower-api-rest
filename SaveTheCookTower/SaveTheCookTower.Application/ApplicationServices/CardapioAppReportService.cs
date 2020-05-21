using Microsoft.Extensions.Localization;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ViewModels.relatorios;
using SaveTheCookTower.CrossCutting.Utils;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveTheCookTower.Application.ApplicationServices
{
	class ItemOcorrenciaParaComputarIngrediente
	{
		public int Semana { get; set; }
		public int DiaDaSemana { get; set; }
		public Guid ReceitaId { get; set; }
		public string NomeReceita { get; set; }
		public int ReceitaPorcoes { get; set; }
		public double ReceitaQuantidade { get; set; }
		public int ItemCardapioPorcoes { get; set; }

		public double ItemCardapioQuantidade
		{
			get
			{

				var QtdPorPorcao = ReceitaQuantidade;
				if (ReceitaPorcoes > 0)
					QtdPorPorcao = ReceitaQuantidade / (double)ReceitaPorcoes;
				return QtdPorPorcao * (double)ItemCardapioPorcoes;
			}
		}

	}
	class ItemParaComputarIngrediente
	{
		public Guid IngredienteId { get; set; }
		public string NomeIngrediente { get; set; }
		public double QuantidadeTotal { get; set; }
		public Guid UnidadeMedidaId { get; set; }
		public string NomeUnidadeMedida { get; set; }
		public string NomeCategoria { get; set; }

		public ItemParaComputarIngrediente()
		{
			Ocorrencias = new List<ItemOcorrenciaParaComputarIngrediente>();
		}

		public IList<ItemOcorrenciaParaComputarIngrediente> Ocorrencias { get; set; }

		public void Add(ItemCardapio itemCardapio, Receita receita, ItemListaIngredientes itemIngrediente)
		{
			Ocorrencias.Add(new ItemOcorrenciaParaComputarIngrediente
			{
				Semana = itemCardapio.Semana,
				DiaDaSemana = itemCardapio.DiaDaSemana,
				ReceitaId = receita.Id,
				NomeReceita = receita.Nome,
				ReceitaPorcoes = receita.RendimentoPorcoes,
				ReceitaQuantidade = itemIngrediente.Quantidade,
				ItemCardapioPorcoes = itemCardapio.Porcoes
			});
		}


	}

	public class CardapioAppReportService : ICardapioAppReportService
	{

		private readonly IStringLocalizer<SharedResource> _localizer;

		private readonly IServiceBase<Cardapio> _service;
		private readonly IServiceBase<ItemCardapio> _itemService;
		private readonly IServiceBase<ItemCardapioReceita> _itemReceitaService;
		private readonly IServiceBase<Receita> _receitaService;
		private readonly IServiceBase<ItemListaIngredientes> _ingredientesService;

		public CardapioAppReportService(
			IStringLocalizer<SharedResource> localizer,
			IServiceBase<Cardapio> service,
			IServiceBase<ItemCardapio> itemService,
			IServiceBase<ItemCardapioReceita> itemReceitaService,
			IServiceBase<Receita> receitaService,
			IServiceBase<ItemListaIngredientes> ingredientesService)
		{
			_localizer = localizer;
			_service = service;
			_itemService = itemService;
			_itemReceitaService = itemReceitaService;
			_receitaService = receitaService;
			_ingredientesService = ingredientesService;

		}

		public CardapioReportResultViewModel Execute(CardapioReportParamsViewModel param)
		{
			var result = new CardapioReportResultViewModel();

			result.Parametros = param;
			result.Titulo = param.Titulo;
			result.Subtitulo = param.Subtitulo;

			Guid id = param.CardapioId ?? Guid.Empty;

			var nomeCardapio = _localizer["Nenhum cardápio definido"].Value;
			var nomeIntervaloSemanas = _localizer["Nenhum intervalo selecionado"].Value;
			var nomeIntervaloItens = nomeIntervaloSemanas;

			Cardapio c = null;
			if (id != Guid.Empty)
				c = _service.GetById(id);

			if (c != null)
			{
				nomeCardapio = c.Nome;
			}

			result.CabecalhoDoRelatorio.Add(new CardapioReportResultValorCabecalhoViewModel
			{
				NomeCampo = _localizer["Cardápio"].Value,
				ValorCampo = nomeCardapio
			});
			result.CabecalhoDoRelatorio.Add(new CardapioReportResultValorCabecalhoViewModel
			{
				NomeCampo = _localizer["Intervalo de semanas"].Value,
				ValorCampo = nomeIntervaloSemanas
			});
			result.CabecalhoDoRelatorio.Add(new CardapioReportResultValorCabecalhoViewModel
			{
				NomeCampo = _localizer["Intervalo de itens"].Value,
				ValorCampo = nomeIntervaloItens
			});

			if (c != null)
			{
				var lista = ObterDadosAgrupados(id);

				//percorre somando
				foreach (var ocor in lista)
				{

					//var SomaReceitaQuantidades = ocor.Ocorrencias.Select(p => p.ReceitaQuantidade).ToList().Sum();
					var SomaItensCardapioQuantidades = ocor.Ocorrencias.Select(p => p.ItemCardapioQuantidade).ToList().Sum();

					ocor.QuantidadeTotal = SomaItensCardapioQuantidades;
				}

				// Ordena por categoria para agrupar
				var ordenada = lista.OrderBy(p => p.NomeCategoria).ToList();

				//Novo cabeçalho para cada mudança de categoria
				string cat = "indefinida"; // deixar em branco dá problema se vir assim também dos dados
				int qtd = 0;
				CardapioReportResultGruposDeRegistrosViewModel grupo = null;
				foreach (var ocor in ordenada)
				{
					if (grupo == null || cat != ocor.NomeCategoria)
					{
						if (grupo != null)
						{
							grupo.RodapeDoGrupo.Add(new CardapioReportResultValorCabecalhoViewModel
							{ NomeCampo = _localizer["Contador"].Value, ValorCampo = qtd.ToString() });
						}

						grupo = new CardapioReportResultGruposDeRegistrosViewModel();
						result.Dados.Add(grupo);

						grupo.CabecalhoDoGrupo.Add(new CardapioReportResultValorCabecalhoViewModel
						{ NomeCampo = "", ValorCampo = ocor.NomeCategoria });

						grupo.Registros.TitulosColunas.Add(_localizer["Item"].Value);
						grupo.Registros.TitulosColunas.Add(_localizer["Ingrediente"].Value);
						grupo.Registros.TitulosColunas.Add(_localizer["Quantidade"].Value);
						grupo.Registros.TitulosColunas.Add(_localizer["Unidade"].Value);

						grupo.Registros.NomesColunas.Add("item");
						grupo.Registros.NomesColunas.Add("ing");
						grupo.Registros.NomesColunas.Add("count");
						grupo.Registros.NomesColunas.Add("unit");

						qtd = 0;
						cat = ocor.NomeCategoria;
					}

					if (grupo != null)
					{
						qtd++;
						grupo.Registros.CommaTextRegisters.Add($"\"item={qtd}\",\"ing={ocor.NomeIngrediente}\",\"count={ocor.QuantidadeTotal}\",\"unit={ocor.NomeUnidadeMedida}\"");
					}
				}

				if (grupo != null)
				{
					grupo.RodapeDoGrupo.Add(new CardapioReportResultValorCabecalhoViewModel
					{ NomeCampo = _localizer["Contador"].Value, ValorCampo = qtd.ToString() });
				}

			}

			return result;

		}


		private List<ItemParaComputarIngrediente> ObterDadosAgrupados(Guid id)
		{
			var from = 0;
			var to = -1;
			var itensCardapio = _itemService.Find(p => p.CardapioId == id, from, to);

			ItemParaComputarIngrediente ocor = null;
			List<ItemListaIngredientes> itensIng = null;
			ItemListaIngredientes itemIngAtual = null;

			var agrupadoPorIng = new List<ItemParaComputarIngrediente>();
			foreach (var item in itensCardapio)
			{
				var itensCardRec = _itemReceitaService.Find(p => p.ItemCardapioId == item.Id, 0, -1);

				foreach (var itemCardRec in itensCardRec)
				{
					itensIng = _ingredientesService.Find(p => p.ReceitaId == itemCardRec.ReceitaId, 0, -1).ToList();
					foreach (var itemIng in itensIng)
					{
						itemIngAtual = itemIng;
						//procura nos agrpamentos
						ocor = agrupadoPorIng.Find(p => p.IngredienteId == itemIngAtual.Ingrediente.Id
						  && p.UnidadeMedidaId == itemIngAtual.UnidadeMedidaId);

						if (ocor == null)
						{
							ocor = new ItemParaComputarIngrediente
							{
								IngredienteId = itemIngAtual.Ingrediente.Id,
								NomeIngrediente = itemIngAtual.Ingrediente.Nome,
								QuantidadeTotal = 0.0,
								UnidadeMedidaId = itemIngAtual.UnidadeMedidaId,
								NomeUnidadeMedida = itemIngAtual.UnidadeMedida.Nome,
								NomeCategoria = ObterCaminhoCategoria(itemIngAtual.Ingrediente)
							};

							ocor.Add(item, itemIngAtual.Receita, itemIngAtual);
							agrupadoPorIng.Add(ocor);
						}
						else
						{
							ocor.Add(item, itemIngAtual.Receita, itemIngAtual);
						}
					}
				}
			}

			return agrupadoPorIng;
		}

		private string ObterCaminhoCategoria(Ingrediente ingrediente)
		{
			Categoria cat = ingrediente?.Categoria;
			string r = "";
			while (cat != null)
			{
				if (r != "") r = " -> " + r;
				r = cat?.Nome + r;
				cat = cat.CategoriaPai;
			}
			return r;
		}
	}
}
