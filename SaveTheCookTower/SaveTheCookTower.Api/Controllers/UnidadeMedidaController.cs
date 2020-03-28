using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;

namespace SaveTheCookTower.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidaController : DefaultControllerForAppServiceController<UnidadeMedidaViewModel>
    {
        const string NOME_PARA_USUARIO = "Unidade de Medida";
        public UnidadeMedidaController(IAppServiceBase<UnidadeMedidaViewModel> appService) : base(appService, NOME_PARA_USUARIO)
        {
            //
        }
    }
}