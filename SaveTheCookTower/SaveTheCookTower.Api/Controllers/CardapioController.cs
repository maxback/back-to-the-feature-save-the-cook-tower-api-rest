using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SaveTheCookTower.Api.Controllers.Base;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Application.ViewModels.relatorios;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [Route("api/Menu")]
    [ApiController]
    [NomeParaUsuario("Cardápio")]
    public class CardapioController : DefaultControllerForAppServiceController<CardapioViewModel>
    {
        private readonly IAppServiceBase<ReceitaViewModel> _appServiceReceita;
        private readonly IAppServiceBase<ItemCardapioViewModel> _appServiceItemCardapio;
        private readonly IAppServiceBase<ItemCardapioReceitaViewModel> _appServiceItemCardapioReceita;

        private readonly ICardapioAppReportService _appReportService;


        public CardapioController(
            ICardapioAppReportService appReportService,
            IAppServiceBase<CardapioViewModel> appService,
            IAppServiceBase<ReceitaViewModel> appServiceReceita,
            IAppServiceBase<ItemCardapioViewModel> appServiceItemCardapio,
            IAppServiceBase<ItemCardapioReceitaViewModel> appServiceItemCardapioReceita,
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            _appReportService = appReportService;

            _appServiceReceita = appServiceReceita;
            _appServiceItemCardapio = appServiceItemCardapio;
            _appServiceItemCardapioReceita = appServiceItemCardapioReceita;
        }

        protected override bool SalvarObjetoFilho(Object viewModel, string nomeItemNoObjetoPai,
            Guid guidObjetoPai, out Guid guidObjetoFilho)
        {
            Guid.TryParse("00000000-0000-0000-0000-000000000000", out guidObjetoFilho);

            //testa os nomes suportados, e dá um jeito de salvar, pegando sua guid e retornando
            switch (nomeItemNoObjetoPai)
            {
                case "ItensAsStr":
                    var strobj = (string)viewModel;

                    var registros = strobj.Split("|||");

                    foreach (var reg in registros)
                    {
                        var item = new ItemCardapioViewModel();
                        item.LercamposDaString(reg);
                        item.CardapioId = guidObjetoPai;
                        var itemSalvo = _appServiceItemCardapio.Add(item);

                        var idItem = itemSalvo.Id ?? Guid.Empty;

                        if (item.ListaIdsReceitas.Length < 1)
                            continue;

                        var receitas = item.ListaIdsReceitas.Split(",");
                        var i = 1;
                        foreach (var rec in receitas)
                        {
                            var itemRec = new ItemCardapioReceitaViewModel();
                            Guid idRec;
                            if (!Guid.TryParse(rec, out idRec))
                                throw new Exception(_localizer["Esperado um Id de receita no {0}o item da lista de receitas do item de cardápio.", (i - 1)].Value);

                            var recConsultada = _appServiceReceita.GetById(idRec);
                            if(recConsultada == null)
                                throw new Exception(_localizer["Esperado um Id de receita no item {0}o da lista de receitas do item de cardápio.", (i - 1)].Value);

                            itemRec.ItemCardapioId = idItem;
                            itemRec.ReceitaId = idRec;
                            itemRec.Nome = recConsultada.Nome;
                            itemRec.Sinonimos = $"Rec {i} - {recConsultada.Nome} do Item de Cardápio semana {item.Semana} dia {item.DiaDaSemana}";

                            _appServiceItemCardapioReceita.Add(itemRec);

                            i++;
                        }
                    }
                    //return true;
                    break;
            }

            return false;
        }


        [HttpGet("{id}/report")]
        public ActionResult GetReportById(Guid id)
        {
            var relNome = _localizer["Lista de Ingredientes"].Value;
            var param = new CardapioReportParamsViewModel();
            param.CardapioId = id;
            param.Titulo = relNome;
            param.Subtitulo = _localizer["Por categoria, totalizando todas as receitas"].Value;
            return GerarRelatorio(param);
            /*
            var result = _appReportService.Execute(param);

            if (result != null)
                return Ok(result);

            return NoContent();
            */
        }

        [HttpGet("{id}/{mostrarDetalhesDoCalculo}/reportex")]
        public ActionResult GetReportExById(Guid id, bool mostrarDetalhesDoCalculo)
        {
            var relNome = _localizer["Lista de Ingredientes"].Value;
            var param = new CardapioReportParamsViewModel();
            param.CardapioId = id;
            param.Titulo = relNome;
            param.Subtitulo = _localizer["Por categoria, totalizando todas as receitas"].Value;
            param.MostrarDetalhesDoCalculo = mostrarDetalhesDoCalculo;

            return GerarRelatorio(param);
            /*
            var result = _appReportService.Execute(param);

            if (result != null)
                return Ok(result);

            return NoContent();
            */
        }

        [HttpPost()]
        [Route("report")]
        public ActionResult GetReportById(CardapioReportParamsViewModel param)
        {
            return GerarRelatorio(param);
        }

        private ActionResult GerarRelatorio(CardapioReportParamsViewModel param)
        {
            var relNome = param.Titulo == string.Empty ? _localizer["Lista de Ingredientes"].Value :
                param.Titulo;
            try
            {

                /*
                param.Titulo = relNome;
                param.Subtitulo = _localizer["Por categoria, totalizando todas as receitas"].Value;
                */

                var result = _appReportService.Execute(param);

                if (result != null)
                    return Ok(result);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Mensagem = _localizer["Ocorreu um erro ao gerar relatório \"{0}\".{1}",
                    relNome, e.Message].Value
                });
            }
        }
    }
}