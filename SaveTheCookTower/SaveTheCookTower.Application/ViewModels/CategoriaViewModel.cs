using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class CategoriaViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		public CategoriaViewModel CategoriaPai { get; set; }
		public Guid? CategoriaPaiId { get; set; }
		public List<CategoriaViewModel> CategoriasFilhas { get; }
		public List<ReceitaViewModel> Receitas { get; }
		public List<IngredienteViewModel> Ingredientes { get; }

		public void LercamposDaString(string strKeyvalueSepVirgula)
		{
			var itens = strKeyvalueSepVirgula.Split(",");
			foreach (var s in itens)
			{
				if (s.Contains("id=") && (s.Length > 3))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					Id = umId;
				}

				if (s.Contains("categoriaPaiId=") && (s.Length > 15))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					CategoriaPaiId = umId;
				}

				if (s.Contains("nome=")) Nome = s.Split("=")[1];
				if (s.Contains("sinonimos=")) Sinonimos = s.Split("=")[1];
				//if (s.Contains("itemUri=")) ItemUri = s.Split("=")[1];
				if (s.Contains("foraDeUso=")) ForaDeUso = s.Split("=")[1] == "true";

			}
		}


	}
}
