using SaveTheCookTower.Domain.Models.Base;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Usuario: ModelBase
	{
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
		public virtual List<AvaliacaoDoUsuario> AvaliacoesFeitasPeloUsuario { get; }
	}
}