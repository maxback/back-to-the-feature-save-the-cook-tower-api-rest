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
    [Route("api/UnitMeasure")]
    [Route("api/um")]
    [ApiController]
    [NomeParaUsuario("Unidade de Medida")]
    public class UnidadeMedidaController : DefaultControllerForAppServiceController<UnidadeMedidaViewModel>
    {
        public UnidadeMedidaController(IAppServiceBase<UnidadeMedidaViewModel> appService,
            IStringLocalizer<SharedResource> localizer)  : base(appService, localizer)
        {
            //
        }

		[Route("LercamposDaString")]
		[HttpPost]
		public ActionResult Post([FromBody] string strKeyvalueSepVirgula)
		{

			var viewModel = new UnidadeMedidaViewModel();
			var idDefault = viewModel.Id;

			viewModel.LercamposDaString(strKeyvalueSepVirgula);

			var idConvertido = Guid.Empty;
			if (viewModel.Id != null)
				idConvertido = (Guid)viewModel.Id;

			if (idConvertido == idDefault)
				return this.Post(viewModel);

			if (idConvertido != idDefault)
				return this.Put(idConvertido, viewModel);

			return BadRequest(new
			{
				Mensagem = _localizer["Ocorreu algum erro ao importar o registro de texto para a tabela {0}.",
					_nomeParaUsuario].Value
			});
		}

	}
}