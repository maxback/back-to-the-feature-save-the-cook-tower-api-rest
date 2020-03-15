using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class IngredientesConfig : IEntityTypeConfiguration<Ingrediente>
	{
		public void Configure(EntityTypeBuilder<Ingrediente> builder)
		{
			builder.DefineBasicConfigs(tableName: "ingrediente");
		}
	}
}
