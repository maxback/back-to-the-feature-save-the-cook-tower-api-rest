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

			builder.HasMany(p => p.EquivalenciasOrigem).WithOne(p => p.Origem).HasForeignKey(p => p.OrigemId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(p => p.EquivalenciasDestino).WithOne(p => p.Destino).HasForeignKey(p => p.DestinoId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(p => p.InformacoesNutricionais).WithOne(p => p.UnidadeMedida).HasForeignKey(p => p.UnidadeMedidaId);

			builder.HasMany(p => p.InformacoesNutricionais).WithOne(p => p.UnidadeMedida).HasForeignKey(p => p.UnidadeMedidaId);

			builder.Property(p => p.Tipo).HasColumnName("n_tipo");
			builder.Property(p => p.NomeResumido).HasColumnName("_nome_resumido");
		}
	}
}
