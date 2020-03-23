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

			builder.HasOne(p => p.Usuario).WithMany(p => p.AvaliacoesFeitasPeloUsuario).HasForeignKey(p => p.UsuarioId);

			builder.HasOne(p => p.Receita).WithOne(p => p.AvaliacaoMedia).HasForeignKey<Receita>(p => p.AvaliacaoMediaId);

			builder.Property(p => p.QuantidadeEstrelas).HasColumnName("qtd_estrelas");
			builder.Property(p => p.UsuarioId).HasColumnName("id_usuario");
			builder.Property(p => p.ReceitaId).HasColumnName("id_receita");
			builder.Property(p => p.AvaliacaoMedia).HasColumnName("b_eh_aval_media");
		}
	}
}
