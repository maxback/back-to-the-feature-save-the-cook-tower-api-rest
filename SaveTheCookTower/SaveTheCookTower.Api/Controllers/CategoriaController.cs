using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [Route("api/Category")]
    [Route("api/cat")]
    [ApiController]
    [NomeParaUsuario("Categoria")]
    public class CategoriaController : DefaultControllerForAppServiceController<CategoriaViewModel>
    {
        public CategoriaController(IAppServiceBase<CategoriaViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }

		[HttpPost]
		[Route("LercamposDaString")]
		public ActionResult Post([FromBody] string strKeyvalueSepVirgula)
		{

			var viewModel = new CategoriaViewModel();
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