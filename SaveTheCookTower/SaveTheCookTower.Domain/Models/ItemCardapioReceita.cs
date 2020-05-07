using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using SaveTheCookTower.CrossCutting.Utils.Enumerations;

namespace SaveTheCookTower.Domain.Models
{
	/// <summary>
	/// Dados de relacionamento indicando as receitas de im item de cardápio
	/// </summary>
	public class ItemCardapioReceita : ModelBase
	{
		public Guid ItemCardapioId { get; set; }
		public virtual ItemCardapio ItemCardapio { get; set; }
		public Guid ReceitaId { get; set; }
		public virtual Receita Receita { get; set; }
	}
}