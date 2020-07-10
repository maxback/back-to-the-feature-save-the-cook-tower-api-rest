using SaveTheCookTower.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class EtapaDePreparoViewModel : ViewModelBase
	{

		public override void LercamposDaString(string strKeyvalueSepVirgula)
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


				if (s.Contains("ordem=")) Ordem = Convert.ToInt32(s.Split("=")[1]);
				if (s.Contains("descricao=")) Descricao = s.Split("=")[1];

				if (s.Contains("receitaId=") && (s.Length > 10))
				{
					Guid recId;
					Guid.TryParse(s.Split("=")[1], out recId);
					ReceitaId = recId;
				}
			}
		}

		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Indica a receita a qual a etapa se refere
		/// </summary>
		public ReceitaViewModel Receita { get; set; }

		/// <summary>
		/// Chave para a receita
		/// </summary>
		public Guid ReceitaId { get; set; }

		/// <summary>
		/// Ordem de execucao do preparo
		/// </summary>
		public int Ordem { get; set; }
		/// <summary>
		/// descrição apra humanos (como as linhas de uma receita)
		/// </summary>
		public string Descricao { get; set; }

	}
}
