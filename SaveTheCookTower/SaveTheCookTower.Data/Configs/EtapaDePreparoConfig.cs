using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class EtapaDePreparoConfig : IEntityTypeConfiguration<EtapaDePreparo>
	{
		public void Configure(EntityTypeBuilder<EtapaDePreparo> builder)
		{
			builder.DefineBasicConfigs(tableName: "etapa_preparo");
		}
	}
}
