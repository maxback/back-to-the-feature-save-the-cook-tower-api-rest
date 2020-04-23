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
    [Route("api/[controller]")]
    [Route("api/NutritionalInformation")]
    [Route("api/NutriInfo")]
    [ApiController]
    [NomeParaUsuario("Informação Nutricional")]
    public class InformacaoNutricionalController : DefaultControllerForAppServiceController<InformacaoNutricionalViewModel>
    {
        public InformacaoNutricionalController(IAppServiceBase<InformacaoNutricionalViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}