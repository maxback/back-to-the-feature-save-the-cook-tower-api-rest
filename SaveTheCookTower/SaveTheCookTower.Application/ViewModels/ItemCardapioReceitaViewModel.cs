using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ItemCardapioReceitaViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }
		public Guid ItemCardapioId { get; set; }
		public virtual ItemCardapioViewModel ItemCardapio { get; set; }
		public Guid ReceitaId { get; set; }
		public virtual ReceitaViewModel Receita { get; set; }
	}
}