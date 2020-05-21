using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels.relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.Interfaces
{
	public interface ICardapioAppReportService : IAppReportServiceBase<CardapioReportParamsViewModel, CardapioReportResultViewModel>
	{
	}
}
