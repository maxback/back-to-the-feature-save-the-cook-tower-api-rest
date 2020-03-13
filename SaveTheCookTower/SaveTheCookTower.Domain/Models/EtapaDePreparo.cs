using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Domain.Models
{
	public class EtapaDePreparo: ModelBase
	{
		/// <summary>
		/// Ordem de execucao do preparo
		/// </summary>
		public int Ordem { get; set; }
		/// <summary>
		/// descrição apra humanos (como as linhas de uma receita)
		/// </summary>
		public string Descricao { get; set; }
	}
}