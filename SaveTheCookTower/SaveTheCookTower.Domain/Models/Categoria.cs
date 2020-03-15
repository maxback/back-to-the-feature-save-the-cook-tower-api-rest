using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Categoria : ModelBase
	{
		public virtual Categoria CategoriaPai { get; set; }
		public Guid CategoriaPaiId { get; set; }

		public virtual List<Categoria> CategoriasFilhas { get; set; }

		public virtual List<Receita> Receitas { get; set; }

	}
}