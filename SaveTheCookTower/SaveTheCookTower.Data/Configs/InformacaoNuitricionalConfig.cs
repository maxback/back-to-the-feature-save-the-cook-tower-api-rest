using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class InformacaoNuitricionalConfig : IEntityTypeConfiguration<InformacaoNutricional>
	{
		public void Configure(EntityTypeBuilder<InformacaoNutricional> builder)
		{
			builder.DefineBasicConfigs(tableName: "info_nutricional");
		}
	}
}
