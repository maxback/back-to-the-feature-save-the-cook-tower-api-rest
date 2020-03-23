using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class IngredienteConfig : IEntityTypeConfiguration<Ingrediente>
	{
		public void Configure(EntityTypeBuilder<Ingrediente> builder)
		{
			builder.DefineBasicConfigs(tableName: "ingrediente");

			builder.HasOne(p => p.Categoria).WithMany(p => p.Ingredientes).HasForeignKey(p => p.CategoriaId);
			
			builder.HasMany(p => p.InformacoesNutricionais).WithOne(p => p.Ingrediente).HasForeignKey(p => p.IngredienteId);

			builder.HasMany(p => p.ItensListaIngredientes).WithOne(p => p.Ingrediente).HasForeignKey(p => p.IngredienteId);

			builder.Property(p => p.CategoriaId).HasColumnName("id_categoria");
			builder.Property(p => p.ImagensUri).HasColumnName("m_imagens_url");

		}
	}
}
