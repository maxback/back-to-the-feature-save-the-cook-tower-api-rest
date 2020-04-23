using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;
using System;

namespace SaveTheCookTower.Api.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[Route("api/UnitsMeasureEquivalence")]
	[Route("api/umeq")]
	[ApiController]
	[NomeParaUsuario("Equivalência entre Unidades de Medida")]
	public class EquivalenciaEntreUnidadesDeMedidaController : DefaultControllerForAppServiceController<EquivalenciaEntreUnidadesDeMedidaViewModel>
	{

		public EquivalenciaEntreUnidadesDeMedidaController(IAppServiceBase<EquivalenciaEntreUnidadesDeMedidaViewModel> appService, 
			IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
		{
			//
		}

	}
}
