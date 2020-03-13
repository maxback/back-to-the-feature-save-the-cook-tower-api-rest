using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class AvaliacaoDoUsuario: ModelBase
	{
		public int? QuantidadeEstrelas { get; set; }
		public Usuario Usuario{ get; set; }
		public Guid UsuarioId { get; set; }
	}
}