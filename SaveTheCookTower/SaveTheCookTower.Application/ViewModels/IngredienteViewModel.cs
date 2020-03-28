using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class IngredienteViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		public virtual CategoriaViewModel Categoria { get; set; }
		public Guid CategoriaId { get; set; }
		/// <summary>
		/// Texto com URLs acessíveis do ingrediente, separadas por ';' Sendo a primeira a principal a adequada a miniaturas
		/// ou exibições.
		/// </summary>
		public string ImagensUri { get; set; }

		public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam este ingrediente
		/// </summary>
		public List<ItemListaIngredientesViewModel> ItensListaIngredientes { get; }

	}
}
