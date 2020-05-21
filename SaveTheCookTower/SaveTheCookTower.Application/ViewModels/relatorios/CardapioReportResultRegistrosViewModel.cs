using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels.relatorios
{
	public class CardapioReportResultRegistrosViewModel
	{
		public CardapioReportResultRegistrosViewModel()
		{
			TitulosColunas = new List<string>();
			NomesColunas = new List<string>();
			CommaTextRegisters = new List<string>();
		}

		public IList<string> TitulosColunas { get; set; }
		public IList<string> NomesColunas { get; set; }
		public IList<string> CommaTextRegisters { get; set; }
	}
}
