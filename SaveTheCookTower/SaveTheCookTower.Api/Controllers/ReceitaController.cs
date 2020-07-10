using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        private readonly IAppServiceBase<EtapaDePreparoViewModel> _appServiceIEtapaPreparoLista;

        public ReceitaController(IAppServiceBase<ReceitaViewModel> appService,
            IAppServiceBase<ItemListaIngredientesViewModel> appServiceItemIngLista,
            IAppServiceBase<EtapaDePreparoViewModel> appServiceIEtapaPreparoLista,
            IStringLocalizer<SharedResource> localizer) : base(appService, localizer)
        {
            _appServiceItemIngLista = appServiceItemIngLista;
            _appServiceIEtapaPreparoLista = appServiceIEtapaPreparoLista;
        }

        protected override void ApagarObjetosFilho(Guid guidObjetoPai)
		{
			ApagarObjetosListaIngredientes(guidObjetoPai);
            ApagarObjetosListaEtapasPreparo(guidObjetoPai);

        }

		private void ApagarObjetosListaIngredientes(Guid guidObjetoPai)
		{
			var listaItensIng = _appServiceItemIngLista.FindChildrenOf(guidObjetoPai, string.Empty, 0, -1);
			foreach (var itemIng in listaItensIng)
			{
                _appServiceItemIngLista.Remove((Guid)itemIng.Id);
			}
		}

        private void ApagarObjetosListaEtapasPreparo(Guid guidObjetoPai)
        {
            var listaItensEtapas = _appServiceIEtapaPreparoLista.FindChildrenOf(guidObjetoPai, string.Empty, 0, -1);
            foreach (var itemEtapas in listaItensEtapas)
            {
                _appServiceIEtapaPreparoLista.Remove((Guid)itemEtapas.Id);
            }
        }

        protected override bool SalvarObjetoFilho(Object viewModel, string nomeItemNoObjetoPai,
            Guid guidObjetoPai, out Guid guidObjetoFilho)
        {
            Guid.TryParse("00000000-0000-0000-0000-000000000000", out guidObjetoFilho);

            string strobj;
            string[] registros;

            //testa os nomes suportados, e dá um jeito de salvar, pegando sua guid e retornando
            switch (nomeItemNoObjetoPai)
            {
                case "IngredientesAsStr":

                    new ItensRececeita<ItemListaIngredientesViewModel>(_appServiceItemIngLista)
                        .AddRegisters(((string)viewModel).Split("|||"), guidObjetoPai);

                break;

                case "EtapasDePreparoAsStr":

                    new ItensRececeita<EtapaDePreparoViewModel>(_appServiceIEtapaPreparoLista)
                        .AddRegisters(((string)viewModel).Split("|||"), guidObjetoPai);
                    
                break;
            }

            //se for o caso de um objeto de lista este pode pércorrer salvando todos e colcoando nos filhos
            //o id do pai (FK) que já os faz itens da lista no modelo, neste caso não faz tanto sentido retornar a guid
            //mas não vai achar propriedade xxxId no pai, então beleza. Melhor retornar o guid zerado


            return false;
        }
        

    }
}