using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [Route("api/User")]
    [Route("api/Usr")]
    [ApiController]
    [NomeParaUsuario("Usuário")]
    public class UsuarioController : DefaultControllerForAppServiceController<UsuarioViewModel>
    {
        public UsuarioController(IAppServiceBase<UsuarioViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}