using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaveTheCookTower.Application.Interfaces.Base;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers.Base
{
    /// <summary>
    /// Classe base que implementa a utilização do IAppService<TModel> neste nível, deixando 
    /// para os ancestrais interfaces específicas além do padrão para os AppServices
    /// </summary>
    //[Route("api/[controller]")]
    //[ApiController]
    public class DefaultControllerForAppServiceController<TViewTModel> : ControllerBase where TViewTModel : class
    {
        protected readonly IStringLocalizer<SharedResource> _localizer;
        protected readonly IAppServiceBase<TViewTModel> _appService;
        protected readonly string _nomeParaUsuario;
        const bool INC_MSG_EXCEPTION = true;

        protected string RecuperarAtributoNomeParaUsuario()
        {
            NomeParaUsuarioAttribute npu = (NomeParaUsuarioAttribute) Attribute.GetCustomAttribute( this.GetType(),
             typeof(NomeParaUsuarioAttribute));

            if (npu == null)
                return string.Empty;

            return npu.Nome;
        }
        public DefaultControllerForAppServiceController(IAppServiceBase<TViewTModel> appService,
            IStringLocalizer<SharedResource> localizer)
        {
            _appService = appService;

            var type = typeof(SharedResource);
            _localizer = localizer;

            string nomeParaUsuario = RecuperarAtributoNomeParaUsuario();

            _nomeParaUsuario = _localizer[nomeParaUsuario];

        }

        [HttpGet]
        public ActionResult Get([FromQuery] string? text, [FromQuery] int? from, [FromQuery] int? to)
        {
            try
            {
                IList<TViewTModel> result = null;
                bool temTexto = text != null;
                bool temIndice = from != null && to != null;
                if ( temTexto || temIndice)
                {
                    if(temTexto)
                    {
                        result = _appService.Find(text, from, to);
                        return Ok(result);
                    }
                    else
                    {
                        result = _appService.Find(string.Empty, from, to);
                        return Ok(result);
                    }
                }
                result = _appService.GetAll();
                
                return Ok(result);
            }
            catch (Exception e)
            {
                string s = INC_MSG_EXCEPTION ? " " + e.Message : "";
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao buscar os dados de {0}.{1}",
                    _nomeParaUsuario, s].Value
                });
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
            catch (Exception e)
            {
                string s = INC_MSG_EXCEPTION ? " " + e.Message : "";
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao buscar os dados do registro de {0} com id {1}.{2}",
                    _nomeParaUsuario, id, s].Value
                });
            }
        }

        protected Guid GetIdFrom(TViewTModel viewModel)
        {
            try
            {
                Guid id = (System.Guid)viewModel.GetType().GetProperty("Id").GetValue(viewModel);

                return id;
            }
            catch (Exception e)
            {
                string s = INC_MSG_EXCEPTION ? " " + _localizer["(Mensagem original do erro: {0})", e.Message] : "";
                throw new Exception(_localizer["Falha ao obter o Id do objeto{0}.", s]);
            }
        }

        [HttpPost]
        public ActionResult Post(TViewTModel viewModel)
        {
            Guid indefinido = Guid.NewGuid();
            Guid id = indefinido;

            try
            {
                viewModel = _appService.Add(viewModel);

                id = GetIdFrom(viewModel);

                return Created($"{Request.Path.Value}/{id}", viewModel);
            }
            catch (Exception e)
            {
                string sid = id == indefinido ? "?" : id.ToString();
                string s = INC_MSG_EXCEPTION ? " " + e.Message : "";

                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao adicionar os dados do registro de {0} com id {1}.{2}",
                    _nomeParaUsuario, sid, s].Value
                });
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody]TViewTModel viewModel)
        {
            try
            {
                var idObj = GetIdFrom(viewModel);

                if (id != idObj)
                    return BadRequest(_localizer["O Id passado na query ({0}) difere do id no objeto({1})",
                        id, idObj].Value);

                _appService.Update(viewModel);

                return Ok();
            }
            catch (Exception e)
            {
                string s = INC_MSG_EXCEPTION ? " " + e.Message : "";

                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao atualizar os dados do registro de {0} com id {1}.{2}",
                    _nomeParaUsuario, id, s].Value
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _appService.Remove(id);

                return Ok();
            }
            catch (Exception e)
            {
                string s = INC_MSG_EXCEPTION ? " " + e.Message : "";
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao apagar os dados do registro de {0} com id {1}.{2}",
                    _nomeParaUsuario, id, s].Value
                }); 
            }
        }

    }
}