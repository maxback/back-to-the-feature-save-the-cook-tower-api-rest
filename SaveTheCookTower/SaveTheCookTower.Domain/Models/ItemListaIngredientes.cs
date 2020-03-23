using SaveTheCookTower.Domain.Interfaces;
using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class ItemListaIngredientes: ModelBase, IItemMensuravel
	{
		public int Ordem { get; set; }
		public double Quantidade { get; set; }
		public UnidadeMedida UnidadeMedida { get; set; }
		public Guid UnidadeMedidaId { get; set; }
		public Ingrediente Ingrediente { get; set; }
		public Guid IngredienteId { get; set; }
		/// <summary>
		/// Objeto que apopnta para a receita a qual o item de lista diz respeito
		/// </summary>
		public virtual Receita Receita { get; set; }
		/// <summary>
		/// Id da receita
		/// </summary>
		public Guid ReceitaId{ get; set; }

	}
}