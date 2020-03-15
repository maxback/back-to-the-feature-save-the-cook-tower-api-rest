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

			builder.HasOne(p => p.Receita).WithMany(p => p.Avaliacoes).HasForeignKey(p => p.ReceitaId);

			builder.HasOne(p => p.Receita).WithOne(p => p.AvaliacaoMedia).HasForeignKey<Receita>(p => p.AvaliacaoMediaId);
		}
	}
}
