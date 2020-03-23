using SaveTheCookTower.Domain.Interfaces;
using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	/// <summary>
	/// Permite descrever um item de uma lista de informação nutricional. Exemplos:
	/// Nome				Sinônimo	Quantidade	UnidadeMedida
	/// ---------------------------------------------------------
	/// Valor energético	calorias	74			kcal	
	/// Carboidrato						0.6			g
	/// Sódio							63			mg
	/// </summary>
	public class InformacaoNutricional: ModelBase, IItemMensuravel
	{
		/// <summary>
		/// Quantidade de nutrientes
		/// </summary>
		public double Quantidade { get; set; }

		/// <summary>
		/// Unidade de medida da informação nutricional
		/// </summary>
		public UnidadeMedida UnidadeMedida { get; set; }

		/// <summary>
		/// Referência ao registro da unidade de medida
		/// </summary>
		public Guid UnidadeMedidaId { get; set; }

		/// <summary>
		/// Ingrediente da qual a informação diz respeito
		/// </summary>
		public virtual Ingrediente Ingrediente { get; set; }

		/// <summary>
		/// Código do ingrediente
		/// </summary>
		public Guid IngredienteId { get; set; }

		/// <summary>
		/// Referência a receita da qual o informação é um item da propriedade
		/// Receita.InformacoesNutricionaisConsolidada
		/// </summary>
		public virtual Receita Receita { get; set; }

		/// <summary>
		/// Código de Referência a receita da qual o informação é um item da propriedade
		/// Receita.InformacoesNutricionaisConsolidada
		/// </summary>
		public Guid ReceitaId { get; set; }
	}
}