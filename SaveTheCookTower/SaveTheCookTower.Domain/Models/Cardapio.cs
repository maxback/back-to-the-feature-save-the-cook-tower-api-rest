using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Domain.Models
{

	/// <summary>
	/// Dados de um Cardápio (que é uma programação de refeições distribuida nos dias)
	/// </summary>
	public class Cardapio: ModelBase
	{
		public Cardapio()
		{
			Itens = new List<ItemCardapio>();
		}
		/// <summary>
		/// Idica a categoria da receita. Exemplo: Carnes, Massas, Sobremesas
		/// </summary>
		public virtual Categoria Categoria { get; set; }

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
		public virtual List<ItemCardapio> Itens { get; }

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
