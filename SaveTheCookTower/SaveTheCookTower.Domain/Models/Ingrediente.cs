using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Ingrediente: ModelBase
	{
		public virtual Categoria Categoria { get; set; }
		public Guid CategoriaId { get; set; }
		public string ImagensUri { get; set; }

		public virtual List<InformacaoNutricional> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam este ingrediente
		/// </summary>
		public virtual List<ItemListaIngredientes> ItensListaIngredientes { get; }
	}
}