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

			builder.HasOne(p => p.UnidadeMedidaDefaultParaListaIngredientes).WithMany(p => p.IngredientesUnidadeDefaultList).HasForeignKey(p => p.UnidadeMedidaDefaultParaListaIngredientesId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.UnidadeMedidaParaListaCompras).WithMany(p => p.IngredientesUnidadeListCompras).HasForeignKey(p => p.UnidadeMedidaParaListaComprasId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(p => p.InformacoesNutricionais).WithOne(p => p.Ingrediente).HasForeignKey(p => p.IngredienteId);

			builder.HasMany(p => p.ItensListaIngredientes).WithOne(p => p.Ingrediente).HasForeignKey(p => p.IngredienteId);

			builder.Property(p => p.CategoriaId).HasColumnName("id_categoria");
			builder.Property(p => p.UnidadeMedidaDefaultParaListaIngredientesId).HasColumnName("id_unidade_medida_default");
			builder.Property(p => p.UnidadeMedidaParaListaComprasId).HasColumnName("id_unidade_medida_compras");
			builder.Property(p => p.CategoriaId).HasColumnName("id_categoria");
			builder.Property(p => p.ImagensUri).HasColumnName("m_imagens_url");
			builder.Property(p => p.Densidade).HasColumnName("n_densidade");

		}
	}
}
