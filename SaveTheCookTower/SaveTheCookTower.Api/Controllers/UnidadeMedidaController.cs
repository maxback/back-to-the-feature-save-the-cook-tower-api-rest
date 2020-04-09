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
using SaveTheCookTower.CrossCuttingIoC;

namespace SaveTheCookTower.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : DefaultControllerForAppServiceController<UnidadeMedidaViewModel>
    {
        const string NOME_PARA_USUARIO = "Unidade de Medida";

        public UnidadeMedidaController(IAppServiceBase<UnidadeMedidaViewModel> appService,
            IStringLocalizer<SharedResource> localizer) 
            : base(appService, localizer, NOME_PARA_USUARIO)
        {
            //
        }
    }
}