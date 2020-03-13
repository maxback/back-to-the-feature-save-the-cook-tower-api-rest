using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class FontePropriedadeIntelectual: ModelBase
	{
		public string Autor { get; set; }
		public string Titulo { get; set; }
		public int? PaginaDoLibro { get; set; }
		public string EdicaoDoLivro { get; set; }
		public Uri OrigemUri { get; set; }
		public DateTime AcessoEm { get; set; }
		public string Comentario { get; set; }
	}
}