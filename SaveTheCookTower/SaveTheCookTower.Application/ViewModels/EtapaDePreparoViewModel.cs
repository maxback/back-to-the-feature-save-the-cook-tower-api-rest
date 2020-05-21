using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class EtapaDePreparoViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Indica a receita a qual a etapa se refere
		/// </summary>
		public ReceitaViewModel Receita { get; set; }

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
