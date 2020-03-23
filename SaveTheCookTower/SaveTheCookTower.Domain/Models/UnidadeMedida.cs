using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public enum TiposDeUnidadesDeMedida : Int32
	{
		Desconhecida,
		Comprimento, // 1 metro
		Unidades, // 1 uinidade de ovo
		Massa,   // 1 kg de arroz
		Volume,  // 1 litro de leite
		Tempo,   // 1 segundo
		Repeticoes,  //10 vezes
		ValorEnergetico  // 74 kcal 
	}
	public class UnidadeMedida: ModelBase
	{
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
		public virtual List<EquivalenciaEntreUnidadesDeMedida> EquivalenciasOrigem { get; }

		/// <summary>
		/// Mesmo de EquivalenciasOrigem
		/// Neste caso aponta para as equivalências de que consta como destino
		/// </summary>
		public virtual List<EquivalenciaEntreUnidadesDeMedida> EquivalenciasDestino { get; }

		/// <summary>
		/// Referencia para as inf. nutricionais que usam a unidade
		/// </summary>
		public virtual List<InformacaoNutricional> InformacoesNutricionais { get; }

		/// <summary>
		/// Referencias de iten de lista de ingredientes que usam esta unidade
		/// Sei, é terrível. Queria fugir disto
		/// </summary>
		public virtual List<ItemListaIngredientes> ItensListaIngredientes { get; }
	}
}