using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class IngredienteViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		public virtual CategoriaViewModel Categoria { get; set; }
		public Guid CategoriaId { get; set; }

		public string NomeCategoria { 
			get {
				return Categoria != null ? Categoria.Nome : "";  
			} 
		}

		/// <summary>
		/// Texto com URLs acessíveis do ingrediente, separadas por ';' Sendo a primeira a principal a adequada a miniaturas
		/// ou exibições.
		/// </summary>
		public string ImagensUri { get; set; }

		public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam este ingrediente
		/// </summary>
		public List<ItemListaIngredientesViewModel> ItensListaIngredientes { get; }

		/// <summary>
		/// Importa de registro no padrão string:
		/// "id=,nome=,sinonimo=,foraDeUso=,(true/false),categoriaId=
		/// </summary>
		/// <param name="strKeyvalueSepVirgula"></param>
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

				if (s.Contains("nome=")) Nome = s.Split("=")[1];
				if (s.Contains("sinonimos=")) Sinonimos = s.Split("=")[1];
				//if (s.Contains("itemUri=")) ItemUri = s.Split("=")[1];
				if (s.Contains("foraDeUso=")) ForaDeUso = s.Split("=")[1] == "true";
				if (s.Contains("categoriaId=") && (s.Length > 12))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					CategoriaId = umId;
				}
			}
		}
	}
}
