using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class CardapioViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Idica a categoria da receita. Exemplo: Carnes, Massas, Sobremesas
		/// </summary>
		public CategoriaViewModel Categoria { get; set; }

		/// <summary>
		/// Id da  categoria
		/// </summary>
		public Guid CategoriaId { get; set; }

		/// <summary>
		/// Trata-se de uma breve do cardápio
		/// </summary>
		public String Descricao { get; set; }

		/// <summary>
		/// Armazena os itens do cardápio com seus atribuitos
		/// </summary>
		public virtual List<ItemCardapioViewModel> Itens { get; }

		/// <summary>
		/// Permite subir os itens do cardápio como string
		/// </summary>
		public string ItensAsStr { get; set; }

		/// <summary>
		/// Lista de Uris para acessar imagens da receita. A primeira poderia ser a de capa e as demais complementares
		/// Verificar se podeser um repositório estático ou um caminho apra consultar a api com GET
		/// </summary>
		public string ImagensUri { get; set; }
		/// <summary>
		/// Lista de Uris para acessar videos da receita.
		/// Verificar se podeser um repositório estático ou um caminho apra consultar a api com GET
		/// </summary>
		public string VideosUri { get; set; }

	}
}
