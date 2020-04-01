using SaveTheCookTower.Domain.Interfaces;
using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class ItemListaIngredientes: ModelBase, IItemMensuravel
	{
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
		public UnidadeMedida UnidadeMedida { get; set; }
		public Guid UnidadeMedidaId { get; set; }
		/// <summary>
		/// Indica a ingrediente cadastrado a ser utilziado
		/// </summary>
		public virtual Ingrediente Ingrediente { get; set; }
		public Guid IngredienteId { get; set; }
		/// <summary>
		/// Indica a que receita pertence esse ingrediente
		/// </summary>
		public virtual Receita Receita { get; set; }
		public Guid ReceitaId{ get; set; }

	}
}