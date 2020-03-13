using SaveTheCookTower.Domain.Models.Base;

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
		/// Token da sessão do usuário
		/// </summary>        
		public string Token { get; set; }

	}
}