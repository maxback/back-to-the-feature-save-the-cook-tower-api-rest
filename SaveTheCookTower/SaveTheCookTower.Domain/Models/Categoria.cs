using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Domain.Models
{
	public class Categoria : ModelBase
	{
		public virtual Categoria CategoriaPai { get; set; }
	}
}