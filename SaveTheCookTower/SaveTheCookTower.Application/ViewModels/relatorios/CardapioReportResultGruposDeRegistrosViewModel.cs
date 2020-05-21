using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels.relatorios
{
	public class CardapioReportResultGruposDeRegistrosViewModel
	{
		public CardapioReportResultGruposDeRegistrosViewModel()
		{
			CabecalhoDoGrupo = new List<CardapioReportResultValorCabecalhoViewModel>();
			Registros = new CardapioReportResultRegistrosViewModel();
			RodapeDoGrupo = new List<CardapioReportResultValorCabecalhoViewModel>();
		}
		public string Titulo { get; set; }

		public IList<CardapioReportResultValorCabecalhoViewModel> CabecalhoDoGrupo { get; set; }
		public CardapioReportResultRegistrosViewModel Registros { get; set; }
		public IList<CardapioReportResultValorCabecalhoViewModel> RodapeDoGrupo { get; set; }
	}
}
