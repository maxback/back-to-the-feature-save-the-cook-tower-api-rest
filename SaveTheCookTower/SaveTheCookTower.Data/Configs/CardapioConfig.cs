using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class CardapioConfig : IEntityTypeConfiguration<Cardapio>
	{
		public void Configure(EntityTypeBuilder<Cardapio> builder)
		{
			builder.DefineBasicConfigs(tableName: "cardapio");

			builder.HasOne(p => p.Categoria).WithMany(p => p.Cardapios).HasForeignKey(p => p.CategoriaId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(p => p.Itens).WithOne(p => p.Cardapio).HasForeignKey(p => p.CardapioId);

			builder.Property(p => p.CategoriaId).HasColumnName("id_cardapio");
			builder.Property(p => p.Descricao).HasColumnName("m_descricao");
			builder.Property(p => p.ImagensUri).HasColumnName("m_imagens_url");
			builder.Property(p => p.VideosUri).HasColumnName("m_videos_url");
		}
	}
}