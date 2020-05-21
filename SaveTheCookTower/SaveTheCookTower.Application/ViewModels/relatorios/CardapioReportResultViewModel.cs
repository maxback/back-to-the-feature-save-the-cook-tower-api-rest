using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels.relatorios
{
	public class CardapioReportResultViewModel
	{
		public CardapioReportResultViewModel()
		{
			CabecalhoDoRelatorio = new List<CardapioReportResultValorCabecalhoViewModel>();
			Dados = new List<CardapioReportResultGruposDeRegistrosViewModel>();
			RodapeDoRelatorio = new List<CardapioReportResultValorCabecalhoViewModel>();

		}
		public CardapioReportParamsViewModel Parametros { get; set; }

		public string Titulo { get; set; }
		public string Subtitulo { get; set; }
		public IList<CardapioReportResultValorCabecalhoViewModel> CabecalhoDoRelatorio { get; set; }
		public IList<CardapioReportResultGruposDeRegistrosViewModel> Dados { get; set; }
		public IList<CardapioReportResultValorCabecalhoViewModel> RodapeDoRelatorio { get; set; }
	}
}
