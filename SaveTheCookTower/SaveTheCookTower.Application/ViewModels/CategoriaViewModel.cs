using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class CategoriaViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		public CategoriaViewModel CategoriaPai { get; set; }
		public Guid CategoriaPaiId { get; set; }
		public List<CategoriaViewModel> CategoriasFilhas { get; }
		public List<ReceitaViewModel> Receitas { get; }
		public List<IngredienteViewModel> Ingredientes { get; }

	}
}
