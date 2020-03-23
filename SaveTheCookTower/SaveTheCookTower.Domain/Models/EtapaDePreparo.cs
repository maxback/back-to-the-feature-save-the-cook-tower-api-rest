using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class EtapaDePreparo: ModelBase
	{
		/// <summary>
		/// Indica a receita a qual a etapa se refere
		/// </summary>
		public virtual Receita Receita { get; set; }
		
		/// <summary>
		/// Chave para a receita
		/// </summary>
		public Guid ReceitaId { get; set; }

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