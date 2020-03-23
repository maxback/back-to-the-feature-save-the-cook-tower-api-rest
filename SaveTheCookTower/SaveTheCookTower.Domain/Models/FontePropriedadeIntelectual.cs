using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class FontePropriedadeIntelectual: ModelBase
	{
		public string Autor { get; set; }
		public string Titulo { get; set; }
		public int? PaginaDoLivro { get; set; }
		public string EdicaoDoLivro { get; set; }
		public Uri OrigemUri { get; set; }
		public DateTime AcessoEmUtc { get; set; }
		public string Comentario { get; set; }
		public List<Receita> Receitas { get;  }
	}
}