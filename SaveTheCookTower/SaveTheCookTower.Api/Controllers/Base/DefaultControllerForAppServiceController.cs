using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveTheCookTower.Application.Interfaces.Base;

namespace SaveTheCookTower.Api.Controllers.Base
{
    /// <summary>
    /// Classe base que implementa a utilização do IAppService<TModel> neste nível, deixando 
    /// para os ancestrais interfaces específicas além do padrão para os AppServices
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultControllerForAppServiceController<TViewTModel> : ControllerBase where TViewTModel : class
    {
        private readonly IAppServiceBase<TViewTModel> _appService;
        private readonly string _nomeParaUsuario;

        public DefaultControllerForAppServiceController(IAppServiceBase<TViewTModel> appService, string nomeParaUsuario)
        {
            _appService = appService;
            _nomeParaUsuario = nomeParaUsuario;

        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = _appService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { Mensagem = $"Ocorreu um erro ao buscar os dados de {_nomeParaUsuario}." });
            }
        }


        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            try
            {
                var result = _appService.GetById(id);

                if (result != null)
                    return Ok(result);

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest(new { Mensagem = $"Ocorreu um erro ao buscar os dados do registro de {_nomeParaUsuario} com id {id}." });
            }
        }
    }
}