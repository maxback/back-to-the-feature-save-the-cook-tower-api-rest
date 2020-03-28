using SaveTheCookTower.CrossCutting.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class UnidadeMedidaViewModel
	{
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Indica que tipo de unidade é esta. Ver TiposDeUnidadesDeMedida
		/// </summary>
		public TiposDeUnidadesDeMedida Tipo { get; set; }

		/// <summary>
		/// Possibilita definir o nome da unidade de forma resumida (como geralmente é usada)
		/// Enquanto Nome pode receber "mililitros", NomeResumido receberia "ml"
		/// </summary>
		public string NomeResumido { get; set; }

		/// <summary>
		/// Esta lista de equivalencias é importante para permitir montar listas de compras ou
		/// calcular quando da receita se pode fazer a partir de uma undiade de determinado produto,
		/// como um quilo de trigo.
		/// Neste caso aponta para as equivalências de que consta como origem
		/// </summary>
		public List<EquivalenciaEntreUnidadesDeMedidaViewModel> EquivalenciasOrigem { get; }

		/// <summary>
		/// Mesmo de EquivalenciasOrigem
		/// Neste caso aponta para as equivalências de que consta como destino
		/// </summary>
		public List<EquivalenciaEntreUnidadesDeMedidaViewModel> EquivalenciasDestino { get; }

		/// <summary>
		/// Referencia para as inf. nutricionais que usam a unidade
		/// </summary>
		public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam esta unidade
		/// Sei, é terrível. Queria fugir disto
		/// </summary>
		public List<ItemListaIngredientesViewModel> ItensListaIngredientes { get; }
	}
}
