using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels.relatorios
{
	public class CardapioReportParamsViewModel
	{
		/// <summary>
		/// Indica o título a ser retornado
		/// </summary>
		public string Titulo{ get; set; }

		/// <summary>
		/// Indica o subtítulo a ser retornado
		/// </summary>
		public string Subtitulo { get; set; }
		/// <summary>
		/// Permite indica de qual cardapio salvo em banco deve ser gerado o relatório
		/// </summary>
		public Guid? CardapioId { get; set; }

		/// <summary>
		/// Se o cardápio não for informado é possível passar um array com os ids (como string)
		/// das receitas a serem consideradas. 
		/// Se forp assado o cardápio esta lsita pdoe ser usada para limitar as receitas do cardápio.
		/// </summary>
		//public string[] ListaReceitas { get; set; }

		/// <summary>
		/// Se informado indica a quantidade de porções a serem consideradas para obter as quantidades de ingredientes
		/// senão informado (0) terá qeu ser passado obreigatóriamente um ´código de cardápio que define as porções
		/// em seus itens.
		/// </summary>
		public int Porcoes { get; set; }

		/// <summary>
		/// espera um par de valores  que se definido, indica as semanaas a serem consideradas (a aprtir de 1)
		/// Se não definido gera o relatório apra todo o cardápio
		/// </summary>
		//public int[] IntervaloDeSemanas { get; set; }

		/// <summary>
		/// Permite definir um intervalo de indices (0 em diante) dos itens de cardápio ordenados por Semana, DiaDaSemana
		/// Usar caso IntervaloDeSemanas não seja definido, já qeu IntervaloDeSemanas é uma forma mais simples deste.
		/// </summary>
		//public int[] IntevaloItensCardapio { get; set; }


	}
}
