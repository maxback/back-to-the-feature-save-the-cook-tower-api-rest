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
    [Route("api/UserRating")]
    [Route("api/ur")]
    [ApiController]
    [NomeParaUsuario("Avaliação do Usuário")]
    public class AvaliacaoDoUsuarioController : DefaultControllerForAppServiceController<AvaliacaoDoUsuarioViewModel>
    {
        public AvaliacaoDoUsuarioController(IAppServiceBase<AvaliacaoDoUsuarioViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}