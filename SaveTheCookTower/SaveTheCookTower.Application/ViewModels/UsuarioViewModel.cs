using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class UsuarioViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// e-mail do usuário para login.
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// Login para entrar no sistema, como opção ao e-mail
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Senha para login.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Token de API do usuário para integração (via API fornecida a parceiros)
		/// </summary>        
		public string Token { get; set; }

		/// <summary>
		/// Lista de avaliações feitas pelo usuário
		/// </summary>
		public List<AvaliacaoDoUsuarioViewModel> AvaliacoesFeitasPeloUsuario { get; }
		


	}
}
