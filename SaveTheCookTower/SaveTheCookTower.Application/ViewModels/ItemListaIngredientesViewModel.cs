using SaveTheCookTower.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ItemListaIngredientesViewModel : ViewModelBase
	{

		public override void LercamposDaString(string strKeyvalueSepVirgula)
		{
			var itens = strKeyvalueSepVirgula.Split(",");
			foreach(var s in itens)
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
				if (s.Contains("quantidade=")) Quantidade = Convert.ToDouble(s.Split("=")[1]);

				if (s.Contains("unidadeMedidaId=") && (s.Length > 16))
				{
					Guid umId;
					Guid.TryParse(s.Split("=")[1], out umId);
					UnidadeMedidaId = umId;
				}

				if (s.Contains("ingredienteId=") && (s.Length > 14))
				{
					Guid ingId;
					Guid.TryParse(s.Split("=")[1], out ingId);
					IngredienteId = ingId;
				}

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
		/// Indica a ordem do item na lsita de ingredientes
		/// </summary>
		public int Ordem { get; set; }
		/// <summary>
		/// Indica a quantidade do ingrediente
		/// </summary>
		public double Quantidade { get; set; }
		/// <summary>
		/// Indica a unidade de medida da receita
		/// </summary>
		public UnidadeMedidaViewModel UnidadeMedida { get; set; }
		public Guid UnidadeMedidaId { get; set; }
		/// <summary>
		/// Indica a ingrediente cadastrado a ser utilziado
		/// </summary>
		public IngredienteViewModel Ingrediente { get; set; }
		public Guid IngredienteId { get; set; }

		/// <summary>
		/// Indica a que receita pertence esse ingrediente
		/// </summary>
		public ReceitaViewModel Receita { get; set; }
		public Guid ReceitaId { get; set; }

	}
}
