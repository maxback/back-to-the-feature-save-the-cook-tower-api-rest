using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Domain.Models
{
	public class ItemListaIngredientes: ModelBase, IItemMensuravel
	{
		public int Ordem { get; set; }
		public double Quantidade { get; set; }
		public UnidadeMedida UnidadeMedida { get; set; }
		public Ingrediente Ingrediente { get; set; }
	}
}