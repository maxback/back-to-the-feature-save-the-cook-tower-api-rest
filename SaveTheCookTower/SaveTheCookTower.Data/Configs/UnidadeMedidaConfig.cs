using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class UnidadeMedidaConfig : IEntityTypeConfiguration<UnidadeMedida>
	{
		public void Configure(EntityTypeBuilder<UnidadeMedida> builder)
		{
			builder.DefineBasicConfigs(tableName: "unidade_medida");
		}
	}
}
