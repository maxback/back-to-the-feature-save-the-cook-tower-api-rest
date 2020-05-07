using System;
using System.Collections.Generic;
using SaveTheCookTower.CrossCutting.Utils.Enumerations;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ItemCardapioViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }


		/// <summary>
		/// Indica o tipo do item, indicando a que se aplica (café da manhã, almoço, etc)
		/// </summary>
		public TipoItemCardapio Tipo { get; set; }

		/// <summary>
		/// Indica a que cardápio diz respeito este item
		/// </summary>
		public Guid CardapioId { get; set; }

		public CardapioViewModel Cardapio { get; set; }

		/// <summary>
		/// Indica a semana. Em um cardápio de uma semanha todos os registros teriam o valor 1
		/// </summary>
		public int Semana { get; set; }

		/// <summary>
		/// Indica o fida da semana (1 = domingo, 2 = segunda, etc)
		/// </summary>
		public int DiaDaSemana { get; set; }

		/// <summary>
		/// Indica quantas porções serão servidas.
		/// Com base neste item pode-se adaptar a receita ao confrontar
		/// as porções dela com a necessidade.
		/// </summary>
		public int Porcoes { get; set; }

		/// <summary>
		/// Indica as receitas que devem ser preparadas neste dia, co mesta quantidade de porções.
		/// É o mais natura, mas se evetualmente se desejar numa refeição uma quantidade
		/// diferente de porções para uam receita, deve-se criar um novo ItemCardapio com Porcoes 
		/// diferente e sua própria lsitra de receitas.
		/// </summary>
		public virtual List<ReceitaViewModel> Receitas { get; }
	}
}