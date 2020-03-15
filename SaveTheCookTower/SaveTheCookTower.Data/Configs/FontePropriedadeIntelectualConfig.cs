using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class FontePropriedadeIntelectualConfig : IEntityTypeConfiguration<FontePropriedadeIntelectual>
	{
		public void Configure(EntityTypeBuilder<FontePropriedadeIntelectual> builder)
		{
			builder.DefineBasicConfigs(tableName: "fonte_prop_intelec");
		}
	}
}
