﻿using Microsoft.AspNetCore.Authorization;
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
    }
}