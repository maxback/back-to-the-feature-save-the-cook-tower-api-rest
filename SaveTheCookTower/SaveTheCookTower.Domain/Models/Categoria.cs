using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Categoria : ModelBase
	{
		public virtual Categoria CategoriaPai { get; set; }
		public Guid? CategoriaPaiId { get; set; }
		public virtual List<Categoria> CategoriasFilhas { get; }
		public virtual List<Receita> Receitas { get;  }
		public virtual List<Ingrediente> Ingredientes { get;  }
		public virtual List<Cardapio> Cardapios { get; }
	}
}