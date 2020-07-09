using System;
using System.Collections.Generic;


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
		/// Indica a undiade de medida naturalmente usada para compras
		/// </summary>
		public virtual UnidadeMedidaViewModel UnidadeMedidaParaListaCompras { get; set; }

		public Guid UnidadeMedidaParaListaComprasId { get; set; }


		/// <summary>
		/// Indica a undiade de medida default para elaborar lista
		/// </summary>
		public virtual UnidadeMedidaViewModel UnidadeMedidaDefaultParaListaIngredientes { get; set; }

		public Guid UnidadeMedidaDefaultParaListaIngredientesId { get; set; }

		/// <summary>
		/// Indica a relação entre a unidade de medidas para receita e para compras, independente do tipo de unidade.  
		/// Exemplos: 5 significa que 5 xicaras de leite equivalem a um litro
		/// </summary>
		public double Densidade { get; set; }


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

				if (s.Contains("unidadeMedidaParaListaComprasId=") && (s.Length > 35))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					UnidadeMedidaParaListaComprasId = umId;
				}

				if (s.Contains("unidadeMedidaDefaultParaListaIngredientesId=") && (s.Length > 45))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					UnidadeMedidaDefaultParaListaIngredientesId = umId;
				}
				if (s.Contains("densidade=")) Densidade = Convert.ToDouble(s.Split("=")[1]);

			}
		}
	}
}
