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

		[HttpGet]
		[Route("{str}/LercamposDaString")]
		public ActionResult Get(string str)
		{
			try
			{
				var s = str.Replace("recebe_valor", "=");
				s = s.Replace("separador", ",");
				var viewModel = new IngredienteViewModel();
				var idDefault = Guid.NewGuid();

				viewModel.LercamposDaString(s);

				var idConvertido = Guid.Empty;
				if (viewModel.Id != null)
					idConvertido = (Guid)viewModel.Id;


				if (idConvertido != idDefault)
				{
					var existente = _appService.GetById(idConvertido);
					if (existente != null)
						return this.Put(idConvertido, viewModel);

				}
				return this.Post(viewModel);

			}
			catch (Exception e)
			{
				string s = e.Message;
				return BadRequest(new
				{
					Mensagem = _localizer["Ocorreu algum erro ao importar o registro de texto para a tabela {0}.{1}",
					_nomeParaUsuario, s].Value
				});
			}

		}
	}
}