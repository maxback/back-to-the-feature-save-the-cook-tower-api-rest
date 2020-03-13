namespace SaveTheCookTower.Domain.Models
{
	public interface IItemMensuravel
	{
		double Quantidade { get; set; }
		UnidadeMedida UnidadeMedida { get; set; }

	}
}
