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
    [Route("api/Recipe")]
    [Route("api/Rec")]
    [ApiController]
    [NomeParaUsuario("Receita")]
    public class ReceitaController : DefaultControllerForAppServiceController<ReceitaViewModel>
    {
        private readonly IAppServiceBase<ItemListaIngredientesViewModel> _appServiceItemIngLista;

        public ReceitaController(IAppServiceBase<ReceitaViewModel> appService,
            IAppServiceBase<ItemListaIngredientesViewModel> appServiceItemIngLista,
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            _appServiceItemIngLista = appServiceItemIngLista;
        }

        
        protected override bool SalvarObjetoFilho(Object viewModel, string nomeItemNoObjetoPai,
            Guid guidObjetoPai, out Guid guidObjetoFilho)
        {
            Guid.TryParse("00000000-0000-0000-0000-000000000000", out guidObjetoFilho);

            //testa os nomes suportados, e dá um jeito de salvar, pegando sua guid e retornando
            switch (nomeItemNoObjetoPai)
            {
                case "IngredientesAsStr":
                    var strobj = (string)viewModel;

                    var registros = strobj.Split("|||");

                    foreach(var reg in registros)
                    {
                        var item = new ItemListaIngredientesViewModel();
                        item.LercamposDaString(reg);
                        item.ReceitaId = guidObjetoPai;
                        _appServiceItemIngLista.Add(item);
                    }
                    //return true;
                break;
/*
                case "Ingredientes":
                    List<ItemListaIngredientesViewModel> ingredientes = (List<ItemListaIngredientesViewModel>)viewModel;
                    if (ingredientes == null)
                        return false;

                    foreach(var item in ingredientes) {
                        item.ReceitaId = guidObjetoPai;
                        _appServiceItemIngLista.Add(item);
                    }
                break;
  */         
                
            }

            //se for o caso de um objeto de lista este pode pércorrer salvando todos e colcoando nos filhos
            //o id do pai (FK) que já os faz itens da lista no modelo, neste caso não faz tanto sentido retornar a guid
            //mas não vai achar propriedade xxxId no pai, então beleza. Melhor retornar o guid zerado


            return false;
        }
        

    }
}