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

			builder.HasOne(p => p.Receita).WithMany(p => p.EstapasDePreparo).HasForeignKey(p => p.ReceitaId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(p => p.ReceitaId).HasColumnName("id_receita");
			builder.Property(p => p.Ordem).HasColumnName("n_ordem");
			builder.Property(p => p.Descricao).HasColumnName("m_descricao");
		}
	}
}
