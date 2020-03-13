using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Domain.Models
{
	/// <summary>
	/// Permite descrever um item de uma lista de informação nutricional. Exemplos:
	/// Nome				Sinônimo	Quantidade	UnidadeMedida
	/// ---------------------------------------------------------
	/// Valor energético	calorias	74			kcal	
	/// Carboidrato						0.6			g
	/// Sódio							63			mg
	/// </summary>
	public class InformacaoNutricional: ModelBase, IItemMensuravel
	{
		public double Quantidade { get; set; }
		public UnidadeMedida UnidadeMedida { get; set; }
	}
}