using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<UsuarioViewModel>
    {
        /// <summary>
        /// Metofdo que testa se os dados de login correspondem e retorna um objeto do usuário
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="usuario"> Usuário correspondente ao login (ou nulo)</param>
        /// <returns>True se aceitou o login</returns>
        public bool Login(string login, string password, out UsuarioViewModel usuario);
        
    }
}
