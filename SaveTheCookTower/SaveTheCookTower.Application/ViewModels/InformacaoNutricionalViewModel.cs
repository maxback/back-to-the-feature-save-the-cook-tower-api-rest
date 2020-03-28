using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class InformacaoNutricionalViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Quantidade de nutrientes
		/// </summary>
		public double Quantidade { get; set; }

		/// <summary>
		/// Unidade de medida da informação nutricional
		/// </summary>
		public UnidadeMedidaViewModel UnidadeMedida { get; set; }

		/// <summary>
		/// Referência ao registro da unidade de medida
		/// </summary>
		public Guid UnidadeMedidaId { get; set; }

		/// <summary>
		/// Ingrediente da qual a informação diz respeito
		/// </summary>
		public IngredienteViewModel Ingrediente { get; set; }

		/// <summary>
		/// Código do ingrediente
		/// </summary>
		public Guid IngredienteId { get; set; }

		/// <summary>
		/// Referência a receita da qual o informação é um item da propriedade
		/// Receita.InformacoesNutricionaisConsolidada
		/// </summary>
		public ReceitaViewModel Receita { get; set; }

		/// <summary>
		/// Código de Referência a receita da qual o informação é um item da propriedade
		/// Receita.InformacoesNutricionaisConsolidada
		/// </summary>
		public Guid ReceitaId { get; set; }

	}
}
