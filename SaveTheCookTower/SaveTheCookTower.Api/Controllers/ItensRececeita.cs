using System;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels.Base;

namespace SaveTheCookTower.Api.Controllers
{
	public class ItensRececeita<TViewTModel> : Object where TViewTModel : ViewModelBase
    {
		private const string ReceitaId = "receitaId=";
		private readonly IAppServiceBase<TViewTModel> _appServiceItemLista;
        public ItensRececeita(IAppServiceBase<TViewTModel> appServiceItemLista)
        {
            _appServiceItemLista = appServiceItemLista;
        }

        public void AddRegisters(string[] registros, Guid guidObjetoPai)
		{
            foreach (var reg in registros)
            {
                TViewTModel item = (TViewTModel)Activator.CreateInstance(typeof(TViewTModel));
                item.LercamposDaString(reg);
                item.LercamposDaString(ReceitaId + guidObjetoPai.ToString());
                //item.ReceitaId = guidObjetoPai;
                _appServiceItemLista.Add(item);
            }
        }

    }
}