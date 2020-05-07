using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SaveTheCookTower.CrossCutting.Utils.Enumerations
{
	/// <summary>
	/// Valores possíveis para o tipo de unidade de medida
	/// </summary>
	public enum TiposDeUnidadesDeMedida : Int32
	{
		[Description("Selecione")]
		Desconhecida,
		[Description("Comprimento")]
		Comprimento, // 1 metro
		[Description("Unidades")]
		Unidades, // 1 uinidade de ovo
		[Description("Massa")]
		Massa,   // 1 kg de arroz
		[Description("Volume")]
		Volume,  // 1 litro de leite
		[Description("Tempo")]
		Tempo,   // 1 segundo
		[Description("Repetições")]
		Repeticoes,  //10 vezes
		[Description("Valor Energético")]
		ValorEnergetico  // 74 kcal 
	};

	public enum TipoItemCardapio : Int32
	{
		[Description("Selecione")]
		Desconhecida,
		[Description("Café da Manhã")]
		CafeDaManha,
		[Description("Lanche da Manhã")]
		LancheDaManha,
		[Description("Almoço")]
		Almoco,
		[Description("Café da Tarde")]
		CafeDaTarde,
		[Description("Jantar")]
		Jantar,
		[Description("Ceia")]
		Ceia,
		[Description("Genérico")]
		GHenerico
	}
}
