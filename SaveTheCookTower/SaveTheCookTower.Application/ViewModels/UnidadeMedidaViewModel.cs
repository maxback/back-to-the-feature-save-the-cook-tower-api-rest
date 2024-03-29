﻿using SaveTheCookTower.CrossCutting.Utils;
using SaveTheCookTower.CrossCutting.Utils.Enumerations;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Application.ViewModels
{
	public class UnidadeMedidaViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }

		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Indica que tipo de unidade é esta. Ver TiposDeUnidadesDeMedida
		/// </summary>
		public TiposDeUnidadesDeMedida Tipo { get; set; }

		/// <summary>
		/// Retorna a descrição calculada de acordo com o tipo
		/// </summary>
		public string DescricaoTipo
		{
			get
			{
				return Utils.GetDescription<TiposDeUnidadesDeMedida>(Tipo);
			}
		}

		/// <summary>
		/// Possibilita definir o nome da unidade de forma resumida (como geralmente é usada)
		/// Enquanto Nome pode receber "mililitros", NomeResumido receberia "ml"
		/// </summary>
		public string NomeResumido { get; set; }

		/// <summary>
		/// Esta lista de equivalencias é importante para permitir montar listas de compras ou
		/// calcular quando da receita se pode fazer a partir de uma undiade de determinado produto,
		/// como um quilo de trigo.
		/// Neste caso aponta para as equivalências de que consta como origem
		/// </summary>
		public List<EquivalenciaEntreUnidadesDeMedidaViewModel> EquivalenciasOrigem { get; }

		/// <summary>
		/// Mesmo de EquivalenciasOrigem
		/// Neste caso aponta para as equivalências de que consta como destino
		/// </summary>
		public List<EquivalenciaEntreUnidadesDeMedidaViewModel> EquivalenciasDestino { get; }

		/// <summary>
		/// Referencia para as inf. nutricionais que usam a unidade
		/// </summary>
		public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam esta unidade
		/// Sei, é terrível. Queria fugir disto
		/// </summary>
		public List<ItemListaIngredientesViewModel> ItensListaIngredientes { get; }


		public void LercamposDaString(string strKeyvalueSepVirgula)
		{
			var itens = strKeyvalueSepVirgula.Split(",");
			foreach (var s in itens)
			{
				if (s.Contains("id="))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					Id = umId;
				}

				if (s.Contains("nome=")) Nome = s.Split("=")[1];
				if (s.Contains("sinonimos=")) Sinonimos = s.Split("=")[1];
				//if (s.Contains("itemUri=")) ItemUri = s.Split("=")[1];
				if (s.Contains("foraDeUso=")) ForaDeUso = s.Split("=")[1] == "true";
				if (s.Contains("nomeResumido=")) NomeResumido = s.Split("=")[1];

				if (s.Contains("tipo="))
				{
					var t = Convert.ToInt32(s.Split("=")[1]);
					Tipo = (TiposDeUnidadesDeMedida) t;
				}
			}
		}

	}



}
