using SaveTheCookTower.Domain.Models.Base;
using System;

namespace SaveTheCookTower.Domain.Models
{
	public class EquivalenciaEntreUnidadesDeMedida: ModelBase
	{
		public virtual UnidadeMedida Origem { get; set; }
		public Guid? OrigemId { get; set; }
		public virtual UnidadeMedida Destino { get; set; }
		public Guid? DestinoId { get; set; }
		/// <summary>
		/// Razão entre a Unidade de Origem ("Origem") com quantidade 1 e a quantidade equivalente na Unidade de Destino ("Destino").
		/// Seria Origem/Destino. Logo se Origem for "Xicara" e Destino for "MiliLitros" estas razão serial
		/// 1 (em xicara) / 200 (em ml) = 1/200 = 0.005
		/// Com esta razão, poderiamos encontrar a quantidade de leite em ml dividindo a quantidade de xicaras pela razão (0.005)
		/// 
		/// xicaras    operação         volume(ml)
		/// 1          / 0.005    =        200
		/// 2          / 0.005    =        400
		/// 
		/// Parece ruim assim, mas é por que a unidade de origem tem valor numérico menor. Tomemos o exemplo de Origem = MiliLitros
		/// e destino = Litros. Neste caso temos a razão = 1000 / 1 = 1000
		/// Agora para encontrarmos a quantidade de leite em litros poderemos dividir a quantidade em ml pela razão (1000)
		/// volume(ml)    operação         volume(l)
		/// 500          / 1000    =        0,5
		/// 1000         / 1000    =        1
		/// 2000         / 1000    =        2
		/// 
		/// </summary>
		public double RazaoOrigemDestino { get; set; }

		/// <summary>
		/// Calculado a partir de RazaoOrigemDestino, salvo
		/// para ser escolhido se conveniente
		/// </summary>
		public double RazaoDestinoOrigem { get
			{
				return ((double)1.0 / RazaoOrigemDestino); 
			}
		}
	}
}