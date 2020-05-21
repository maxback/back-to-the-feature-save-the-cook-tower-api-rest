using System;
using System.Collections.Generic;
using SaveTheCookTower.CrossCutting.Utils.Enumerations;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ItemCardapioViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }



		public void LercamposDaString(string strKeyvalueSepVirgula)
		{
			var sep = ",";
			if(strKeyvalueSepVirgula.Substring(0,1) == "\"")
			{
				sep = "\",\"";
				strKeyvalueSepVirgula = strKeyvalueSepVirgula.Remove(0, 1);
				if (strKeyvalueSepVirgula.Substring(strKeyvalueSepVirgula.Length - 1, 1) == "\"")
    			  strKeyvalueSepVirgula = strKeyvalueSepVirgula.Remove(strKeyvalueSepVirgula.Length - 1, 1);
			}

			var itens = strKeyvalueSepVirgula.Split(sep);
			
			foreach (var s in itens)
			{
				if (s.Contains("id=") && (s.Length > 3))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					Id = umId;
				}

				if (s.Contains("nome=")) Nome = s.Split("=")[1];
				if (s.Contains("sinonimos=")) Sinonimos = s.Split("=")[1];
				//if (s.Contains("itemUri=")) ItemUri = s.Split("=")[1];
				if (s.Contains("foraDeUso=")) ForaDeUso = s.Split("=")[1] == "true";



				if (s.Contains("tipo=")) Tipo = (TipoItemCardapio)Convert.ToInt32(s.Split("=")[1]);

				if (s.Contains("cardapioId=") && (s.Length > 16))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					CardapioId = umId;
				}

				if (s.Contains("semana=")) Semana = Convert.ToInt32(s.Split("=")[1]);
				if (s.Contains("diaDaSemana=")) DiaDaSemana = Convert.ToInt32(s.Split("=")[1]);
				if (s.Contains("porcoes=")) Porcoes = Convert.ToInt32(s.Split("=")[1]);
				
				if (s.Contains("listaIdsReceitas=")) ListaIdsReceitas = s.Split("=")[1];
			}
		}


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
		public virtual List<ItemCardapioReceitaViewModel> ItensCardapioReceita { get; }

		/// <summary>
		/// permite passar os itens de receitas copm os códigos das receitas simplesmente
		/// para converter para ItensCardapioReceita
		/// </summary>
		public string ListaIdsReceitas { get; set; }
	}
}