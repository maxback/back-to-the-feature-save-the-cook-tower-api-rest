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
		/// Indica a relação média entre massa e volume (kg/m3 no SI).  
		/// Exemplos: 1 significa que para um litro de água temos 1 kiligrama de água
		///           700 significa que para 1m3 de trigo temos 700 kilogramas de trigo.
		///           ou para uma xicara de xá (0,0001479 m3) temos 103,53 gramas  (700 kg/m3 * 0.0001479 m3 = 0,10353 kg)
		///             ** É apenas um exemplo, teria que cadastrar valores reais ***
		/// Ver https://www.convert-me.com/pt/convert/volume/apteacup.html?u=apteacup&v=1
		/// </summary>
		public double Densidade { get; set; }

		public virtual List<InformacaoNutricional> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam este ingrediente
		/// </summary>
		public virtual List<ItemListaIngredientes> ItensListaIngredientes { get; }

	}
}