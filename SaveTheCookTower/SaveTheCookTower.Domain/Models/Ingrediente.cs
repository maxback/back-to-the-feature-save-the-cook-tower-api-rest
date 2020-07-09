using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Ingrediente: ModelBase
	{
		public virtual Categoria Categoria { get; set; }
		public Guid CategoriaId { get; set; }
		/// <summary>
		/// Texto com URLs acessíveis do ingrediente, separadas por ';' Sendo a primeira a principal a adequada a miniaturas
		/// ou exibições.
		/// </summary>
		public string ImagensUri { get; set; }

		
		/// <summary>
		/// Indica a undiade de medida naturalmente usada para compras
		/// </summary>
		public virtual UnidadeMedida UnidadeMedidaParaListaCompras { get; set; }

		public Guid UnidadeMedidaParaListaComprasId { get; set; }


		/// <summary>
		/// Indica a undiade de medida default para elaborar lista
		/// </summary>
		public virtual UnidadeMedida UnidadeMedidaDefaultParaListaIngredientes { get; set; }

		public Guid UnidadeMedidaDefaultParaListaIngredientesId { get; set; }

		/// <summary>
		/// Indica a relação entre a unidade de medidas para receita e para compras, independente do tipo de unidade.  
		/// Exemplos: 5 significa que 5 xicaras de leite equivalem a um litro
		/// </summary>
		public double Densidade { get; set; }

		public virtual List<InformacaoNutricional> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam este ingrediente
		/// </summary>
		public virtual List<ItemListaIngredientes> ItensListaIngredientes { get; }

	}
}