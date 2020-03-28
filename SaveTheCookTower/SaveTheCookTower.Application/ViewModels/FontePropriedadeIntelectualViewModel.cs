using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class FontePropriedadeIntelectualViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Além da propriedade Nome, Esta define o autor (como de um livro, artigo, etc) 
		/// </summary>
		public string Autor { get; set; }
		/// <summary>
		/// Título da obra onde a informação foi obtida
		/// </summary>
		public string Titulo { get; set; }
		/// <summary>
		/// Número da página do livro, se aplicável
		/// </summary>
		public int? PaginaDoLivro { get; set; }
		/// <summary>
		/// Edição do livro, se aplicaável
		/// </summary>
		public string EdicaoDoLivro { get; set; }
		/// <summary>
		/// URL da origem da informação, como a página onde foi publicada
		/// </summary>
		public Uri OrigemUri { get; set; }
		/// <summary>
		/// Data de acesso a informação (na página web, por exemplo)
		/// </summary>
		public DateTime AcessoEmUtc { get; set; }
		/// <summary>
		/// Açgum cometário cabível sobre a fonte
		/// </summary>
		public string Comentario { get; set; }
		/// <summary>
		/// Referência as receitas com esta mesma fonte
		/// </summary>
		public List<ReceitaViewModel> Receitas { get; }

	}
}
