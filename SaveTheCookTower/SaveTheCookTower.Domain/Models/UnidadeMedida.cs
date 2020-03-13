using SaveTheCookTower.Domain.Models.Base;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public enum TipoUnidadeMedida : ushort
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
		public TipoUnidadeMedida Tipo { get; set; }

		/// <summary>
		/// Possibilita definir o nome da unidade de forma resumida (como geralmente é usada)
		/// Enquanto Nome pode receber "mililitros", NomeResumido receberia "ml"
		/// </summary>
		public string NomeResumido { get; set; }

		/// <summary>
		/// Esta lsita de equivalencias é importante para permitir montar listas de compras ou
		/// calcular quando da receita se pode fazer a partir de uma undiade de determinado produto,
		/// como um quilo de trigo
		/// </summary>
		public virtual List<EquivalenciaEntreUnidadesDeMedida> Equivalencias{ get; set; }
	}
}