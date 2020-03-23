using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Domain.Interfaces
{
	public interface IItemMensuravel
	{
		double Quantidade { get; set; }
		UnidadeMedida UnidadeMedida { get; set; }

	}
}
