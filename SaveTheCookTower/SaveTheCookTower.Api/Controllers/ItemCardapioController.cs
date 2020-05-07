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
    [Route("api/MenuItem")]
    [Route("api/mi")]
    [ApiController]
    [NomeParaUsuario("Item de Cardápio")]
    public class ItemCardapioController : DefaultControllerForAppServiceController<ItemCardapioViewModel>
    {
        public ItemCardapioController(IAppServiceBase<ItemCardapioViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}