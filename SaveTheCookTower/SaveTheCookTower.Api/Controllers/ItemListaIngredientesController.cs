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
    [Route("api/IngredientListItem")]
    [Route("api/IngListItem")]
    [ApiController]
    [NomeParaUsuario("Item de Lista de Ingredientes")]
    public class ItemListaIngredientesController : DefaultControllerForAppServiceController<ItemListaIngredientesViewModel>
    {
        public ItemListaIngredientesController(IAppServiceBase<ItemListaIngredientesViewModel> appService, 
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            //
        }
    }
}