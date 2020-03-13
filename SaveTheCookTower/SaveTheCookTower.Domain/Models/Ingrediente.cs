using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace SaveTheCookTower.Domain.Models
{
	public class Ingrediente: ModelBase
	{
		public virtual Categoria Categoria { get; set; }
		public virtual List<Uri> ImagensUri { get; set; }

		public virtual List<InformacaoNutricional> InformacaoNutricional { get; set; }

	}
}