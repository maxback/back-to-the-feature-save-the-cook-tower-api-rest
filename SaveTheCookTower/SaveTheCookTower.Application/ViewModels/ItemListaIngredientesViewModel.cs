using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ItemListaIngredientesViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Indica a ordem do item na lsita de ingredientes
		/// </summary>
		public int Ordem { get; set; }
		/// <summary>
		/// Indica a quantidade do ingrediente
		/// </summary>
		public double Quantidade { get; set; }
		/// <summary>
		/// Indica a unidade de medida da receita
		/// </summary>
		public UnidadeMedidaViewModel UnidadeMedida { get; set; }
		public Guid UnidadeMedidaId { get; set; }
		/// <summary>
		/// Indica a ingrediente cadastrado a ser utilziado
		/// </summary>
		public IngredienteViewModel Ingrediente { get; set; }
		public Guid IngredienteId { get; set; }
		/// <summary>
		/// Indica a que receita pertence esse ingrediente
		/// </summary>
		public virtual ReceitaViewModel Receita { get; set; }
		public Guid ReceitaId { get; set; }

	}
}
