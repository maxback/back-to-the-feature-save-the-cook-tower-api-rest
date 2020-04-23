using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers
{
	//[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	[Route("api/Ingredient")]
	[Route("api/ing")]
	[NomeParaUsuario("Ingrediente")]
	public class IngredienteController : DefaultControllerForAppServiceController<IngredienteViewModel>
	{
		public IngredienteController(IAppServiceBase<IngredienteViewModel> appService, 
			IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
		{
			//
		}
	}
}
