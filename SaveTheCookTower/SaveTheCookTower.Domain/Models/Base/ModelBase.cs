using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Domain.Models.Base
{
	public class ModelBase
	{
		public Guid Id { get; set; }
		public DateTime? CriadoEmUtc { get; set; }
		public Guid? CriadoPorId { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? AtualizadoPorId { get; set; }
		public bool ForaDeUso { get; set; }
		public string Nome { get; set; }
		/// <summary>
		/// Permite indicar sinonimos para o nome, separados por ,
		/// </summary>
		public string Sinonimos { get; set; }
		/// <summary>
		/// Trata-se do link para buscar via o item
		/// </summary>
		/// 
		public Uri ItemUri { get; set; }

		public ModelBase()
		{
			IncializarNovoObjeto();
		}

		public void IncializarNovoObjeto()
		{
			Id = Guid.NewGuid();
			CriadoEmUtc = DateTime.UtcNow;
			AtualizadoEmUtc = DateTime.UtcNow;
			ForaDeUso = false;
		}

		public void RegistrarAlteracao(Guid? atualizadoPorId, DateTime? atualizadoEmUtl)
		{
			if (atualizadoPorId != null)
				AtualizadoPorId = atualizadoPorId;
				
			if (atualizadoEmUtl != null)
				AtualizadoEmUtc = atualizadoEmUtl;
			else
				AtualizadoEmUtc = DateTime.UtcNow;
		}
	}
}
