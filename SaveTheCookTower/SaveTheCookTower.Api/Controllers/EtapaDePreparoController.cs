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
    [Authorize]
    [Route("api/[controller]")]
    [Route("api/PreparationStep")]
    [Route("api/PrepStep")]
    [ApiController]
    [NomeParaUsuario("Etapa de Preparo")]
    public class EtapaDePreparoController : DefaultControllerForAppServiceController<EtapaDePreparoViewModel>
    {
        public EtapaDePreparoController(IAppServiceBase<EtapaDePreparoViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}