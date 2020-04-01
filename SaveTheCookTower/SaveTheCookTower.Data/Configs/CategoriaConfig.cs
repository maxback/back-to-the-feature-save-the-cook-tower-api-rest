using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.DefineBasicConfigs(tableName: "categoria");

			builder.HasMany(p => p.Receitas).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);

			builder.HasMany(p => p.CategoriasFilhas).WithOne(p => p.CategoriaPai).HasForeignKey(p => p.CategoriaPaiId);

			builder.HasOne(p => p.CategoriaPai).WithMany(p => p.CategoriasFilhas).HasForeignKey(p => p.CategoriaPaiId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(p => p.CategoriaPaiId).HasColumnName("id_categoria_pai");

		}
	}
}