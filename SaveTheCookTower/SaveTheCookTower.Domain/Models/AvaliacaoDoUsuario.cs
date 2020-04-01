using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class AvaliacaoDoUsuario: ModelBase
	{
		public int? QuantidadeEstrelas { get; set; }
		public virtual Usuario Usuario { get; set; }
		public Guid UsuarioId { get; set; }
		/// <summary>
		/// Aponta a receita da qual esta é  das avaliações de sua lista de avaliações;
		/// </summary>
		public virtual Receita? Receita { get; set; }

		public Guid? ReceitaId { get; set; }

		/// <summary>
		/// Aponta a receita da qual esta é a avaliação média
		/// </summary>
		public virtual Receita? ReceitaDeQuemEhAvaliacaoMedia { get; set; }

		public Guid? ReceitaDeQuemEhAvaliacaoMediaId { get; set; }

		/// <summary>
		/// Apenas para facilitar algum select, pois pdoereia-se obter isto pelos registros referenciados
		/// por Receita.AvaliacaoMedia (AvaliacaoMediaId) ou testando se ReceitaDeQuemEhAvaliacaoMediaId está definido 
		/// </summary>
		public bool AvaliacaoMedia { get; set; }
	}
}