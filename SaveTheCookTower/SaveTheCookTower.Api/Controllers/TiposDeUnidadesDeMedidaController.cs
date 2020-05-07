using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;
using SaveTheCookTower.CrossCutting.Utils.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveTheCookTower.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [Route("api/TypesofUnitMeasure")]
    [Route("api/toum")]
    [ApiController]
    public class TiposDeUnidadesDeMedidaController : ControllerBase
    {
        private string _nomeParaUsuario = "Tipos de Unidade de Medida";
        protected readonly IStringLocalizer<SharedResource> _localizer;

        public TiposDeUnidadesDeMedidaController(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            _nomeParaUsuario = _localizer[_nomeParaUsuario];
        }
        private IList<TipoEnumeradoViewModel> MontarListaCompleta()
        {
            IList<TipoEnumeradoViewModel> result = new List<TipoEnumeradoViewModel>();

            var values = Enum.GetValues(typeof(TiposDeUnidadesDeMedida)).Cast<TiposDeUnidadesDeMedida>();

            foreach (var val in values)
            {
                var s = Utils.GetDescription<TiposDeUnidadesDeMedida>(val);
                result.Add(new TipoEnumeradoViewModel { Codigo = (int)val, Descricao = s });
            }

            return result;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string? text, [FromQuery] int? from, [FromQuery] int? to)
        {
            try
            {
                var result = MontarListaCompleta();
                int skip = from ?? 0;
                int take = to ?? result.Count()-1;
                take += 1;

                bool temTexto = text != null;
                bool temIndice = from != null && to != null;
                if (temTexto || temIndice)
                {
                    if (temTexto)
                    {
                        result = result.Where<TipoEnumeradoViewModel>(
                            p => p.Descricao.ToLower().Contains(text.ToLower())).Take(take).Skip(skip).ToList();
                        return Ok(result);
                    }
                    else
                    {
                        result = result.Take(take).Skip(skip).ToList();
                        return Ok(result);
                    }
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao montar lista de {0}.{1}",
                    _nomeParaUsuario, e.Message].Value
                });
            }
        }


        [HttpGet("{codigo}")]
        public ActionResult GetById(int codigo)
        {
            try
            {
                var result = MontarListaCompleta();

                result = result.Where<TipoEnumeradoViewModel>(p => p.Codigo == codigo).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao montar lista de {0}.{1}",
                    _nomeParaUsuario, e.Message].Value
                });
            }
        }
    }
}
