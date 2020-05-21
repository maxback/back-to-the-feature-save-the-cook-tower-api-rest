using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class AvaliacaoDoUsuarioViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		public int? QuantidadeEstrelas { get; set; }
		public UsuarioViewModel Usuario { get; set; }
		public Guid UsuarioId { get; set; }
		public ReceitaViewModel Receita { get; set; }
		public Guid ReceitaId { get; set; }
		/// <summary>
		/// Apenas para facilitar algum select, pois pdoereia-se obter isto pelos registros referenciados
		/// por Receita.AvaliacaoMedia (AvaliacaoMediaId)
		/// </summary>
		public bool AvaliacaoMedia { get; set; }
	}
}
