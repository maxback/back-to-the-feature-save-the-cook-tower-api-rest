using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class AvaliacaoDoUsuarioConfig : IEntityTypeConfiguration<AvaliacaoDoUsuario>
	{
		public void Configure(EntityTypeBuilder<AvaliacaoDoUsuario> builder)
		{
			builder.DefineBasicConfigs(tableName: "avaliacao_usuario");
		}
	}
}
