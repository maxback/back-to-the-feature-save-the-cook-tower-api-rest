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
		private readonly IServiceBase<Receita> _receitaService;

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

		public string gerarTextoDetalhe ()
		{
			var rec = _receitaService.GetById(ReceitaId);
			string srec = rec.Nome;
			
			return $"Semana/Dia:{Semana}/{DiaDaSemana}: Quantidade: {ItemCardapioQuantidade} (quant.: {ReceitaQuantidade} ponderada de {ReceitaPorcoes} porções da receita para {ItemCardapioPorcoes} porções do cardápio) - Receita: {srec}";
		}


		public ItemOcorrenciaParaComputarIngrediente(
			IServiceBase<Receita> receitaService)
		{
			_receitaService = receitaService;


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

		public IList<string> ItensDemostrativo { get; set; }

		private readonly IServiceBase<Receita> _receitaService;
		private readonly CardapioReportParamsViewModel _param;

		public ItemParaComputarIngrediente(IServiceBase<Receita> receitaService,
			CardapioReportParamsViewModel param)
		{
			Ocorrencias = new List<ItemOcorrenciaParaComputarIngrediente>();
			ItensDemostrativo = new List<string>();
			_receitaService = receitaService;
			_param = param;
		}

		public IList<ItemOcorrenciaParaComputarIngrediente> Ocorrencias { get; set; }

		public void Add(ItemCardapio itemCardapio, Receita receita, ItemListaIngredientes itemIngrediente)
		{
			var o = new ItemOcorrenciaParaComputarIngrediente(_receitaService)
			{
				Semana = itemCardapio.Semana,
				DiaDaSemana = itemCardapio.DiaDaSemana,
				ReceitaId = receita.Id,
				NomeReceita = receita.Nome,
				ReceitaPorcoes = receita.RendimentoPorcoes,
				ReceitaQuantidade = itemIngrediente.Quantidade,
				ItemCardapioPorcoes = itemCardapio.Porcoes
			};

			Ocorrencias.Add(o);

			if (_param.MostrarDetalhesDoCalculo)
				ItensDemostrativo.Add(o.gerarTextoDetalhe());
		}

		public void Add(int porcoes, Receita receita, ItemListaIngredientes itemIngrediente)
		{
			var o = new ItemOcorrenciaParaComputarIngrediente(_receitaService)
			{
				Semana = 1,
				DiaDaSemana = 0,
				ReceitaId = receita.Id,
				NomeReceita = receita.Nome,
				ReceitaPorcoes = receita.RendimentoPorcoes,
				ReceitaQuantidade = itemIngrediente.Quantidade,
				ItemCardapioPorcoes = porcoes
			};

			Ocorrencias.Add(o);

			if (_param.MostrarDetalhesDoCalculo)
				ItensDemostrativo.Add(o.gerarTextoDetalhe());
		}

	}

	public class CardapioAppReportService : ICardapioAppReportService
	{

		private readonly IStringLocalizer<SharedResource> _localizer;
		private CardapioReportParamsViewModel _param;

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
			_param = param;
			var result = new CardapioReportResultViewModel();

			result.Parametros = param;
			result.Titulo = param.Titulo;
			result.Subtitulo = param.Subtitulo;

			Guid id = param.CardapioId ?? Guid.Empty;

			var nomeCardapio = _localizer["Nenhum cardápio definido"].Value;
			var nomeIntervaloSemanas = _localizer["Nenhum intervalo selecionado"].Value;
			var nomeIntervaloItens = nomeIntervaloSemanas;

			var listaReceitasSemCardapio = string.Empty;
			IList<Receita> listaReceitas = new List<Receita>();

			List<ItemParaComputarIngrediente> lista = null;

			Cardapio c = null;
			if (id != Guid.Empty)
			{
				c = _service.GetById(id);
			}

			if (param.ListaReceitas != null && param.ListaReceitas.Count > 0)
			{


				foreach (var sid in param.ListaReceitas)
				{
					Guid idrec;
					if (Guid.TryParse(sid, out idrec))
					{
						var rec = _receitaService.GetById(idrec);
						if (listaReceitasSemCardapio != string.Empty)
							listaReceitasSemCardapio += ", ";
						listaReceitasSemCardapio += rec.Nome;

						listaReceitas.Add(rec);
					}
				}

				lista = ObterDadosAgrupadosListaReceitas(listaReceitas, param.Porcoes);
			}
			else if (c != null)
			{
				nomeCardapio = c.Nome;
				lista = ObterDadosAgrupados(id);
			}

			ConfigurarCabecalho(param, result, nomeCardapio, nomeIntervaloSemanas, 
				nomeIntervaloItens, listaReceitasSemCardapio);

			if (lista == null)
				return result;

			//percorre somando
			foreach (var ocor in lista)
			{
				if (param.MostrarDetalhesDoCalculo)
				{
					foreach (var o in ocor.Ocorrencias)
					{
						//aqui
						//o.gerarTextoDetalhe
					}
				}


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

					if (_param.MostrarDetalhesDoCalculo)
					{
						grupo.Registros.TitulosColunas.Add(_localizer["Informação Adicional"].Value);
						grupo.Registros.NomesColunas.Add("infoadic");
					}

					qtd = 0;
					cat = ocor.NomeCategoria;
				}

				if (grupo != null)
				{
					qtd++;
					var qtdTotal = Math.Round(ocor.QuantidadeTotal, 1, MidpointRounding.ToEven);
					
					var sreg = $"\"item={qtd}\",\"ing={ocor.NomeIngrediente}\",\"count={qtdTotal}\",\"unit={ocor.NomeUnidadeMedida}\"";
					if (_param.MostrarDetalhesDoCalculo)
					{
						var texto = string.Join("|||", ocor.ItensDemostrativo);
						sreg = $"{sreg},\"infoadic={texto}\"";
					}
					grupo.Registros.CommaTextRegisters.Add(sreg);
				}
			}

			if (grupo != null)
			{
				grupo.RodapeDoGrupo.Add(new CardapioReportResultValorCabecalhoViewModel
				{ NomeCampo = _localizer["Contador"].Value, ValorCampo = qtd.ToString() });
			}


			return result;

		}

		private void ConfigurarCabecalho(CardapioReportParamsViewModel param, CardapioReportResultViewModel result, string nomeCardapio, string nomeIntervaloSemanas, string nomeIntervaloItens, string listaReceitasSemCardapio)
		{
			if (listaReceitasSemCardapio != string.Empty)
			{
				result.CabecalhoDoRelatorio.Add(new CardapioReportResultValorCabecalhoViewModel
				{
					NomeCampo = _localizer["Lista de receitas"].Value,
					ValorCampo = listaReceitasSemCardapio
				});
				result.CabecalhoDoRelatorio.Add(new CardapioReportResultValorCabecalhoViewModel
				{
					NomeCampo = _localizer["Porções"].Value,
					ValorCampo = param.Porcoes.ToString()
				}); ;

			}
			else
			{
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
			}
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
							ocor = new ItemParaComputarIngrediente(_receitaService, _param)
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

		private List<ItemParaComputarIngrediente> ObterDadosAgrupadosListaReceitas(IList<Receita> listaReceitas, int porcoes)
		{
			var from = 0;
			var to = -1;
			/*
			var itensCardapio = _itemService.Find(p => p.CardapioId == id, from, to);
			*/
			ItemParaComputarIngrediente ocor = null;
			List<ItemListaIngredientes> itensIng = null;
			ItemListaIngredientes itemIngAtual = null;

			var agrupadoPorIng = new List<ItemParaComputarIngrediente>();
			foreach(var rec in listaReceitas)
			{
				itensIng = _ingredientesService.Find(p => p.ReceitaId == rec.Id, 0, -1).ToList();
				foreach (var itemIng in itensIng)
				{
					itemIngAtual = itemIng;
					//procura nos agrpamentos
					ocor = agrupadoPorIng.Find(p => p.IngredienteId == itemIngAtual.Ingrediente.Id
						&& p.UnidadeMedidaId == itemIngAtual.UnidadeMedidaId);

					if (ocor == null)
					{
						ocor = new ItemParaComputarIngrediente(_receitaService, _param)
						{
							IngredienteId = itemIngAtual.Ingrediente.Id,
							NomeIngrediente = itemIngAtual.Ingrediente.Nome,
							QuantidadeTotal = 0.0,
							UnidadeMedidaId = itemIngAtual.UnidadeMedidaId,
							NomeUnidadeMedida = itemIngAtual.UnidadeMedida.Nome,
							NomeCategoria = ObterCaminhoCategoria(itemIngAtual.Ingrediente)
						};

						ocor.Add(porcoes, itemIngAtual.Receita, itemIngAtual);
						agrupadoPorIng.Add(ocor);
					}
					else
					{
						ocor.Add(porcoes, itemIngAtual.Receita, itemIngAtual);
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
