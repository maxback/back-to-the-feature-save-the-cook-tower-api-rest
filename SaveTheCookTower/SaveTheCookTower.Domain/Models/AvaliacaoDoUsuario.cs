using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class AvaliacaoDoUsuario: ModelBase
	{
		public int? QuantidadeEstrelas { get; set; }
		public Usuario Usuario{ get; set; }
		public Guid UsuarioId { get; set; }
		public Receita Receita { get; set; }
		public Guid ReceitaId { get; set; }
		/// <summary>
		/// Apenas para facilitar algum select, pois pdoereia-se obter isto pelos registros referenciados
		/// por Receita.AvaliacaoMedia (AvaliacaoMediaId)
		/// </summary>
		public bool AvaliacaoMedia { get; set; }
	}
}