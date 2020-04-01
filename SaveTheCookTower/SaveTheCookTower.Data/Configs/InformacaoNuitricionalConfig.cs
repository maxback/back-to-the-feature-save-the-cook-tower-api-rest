using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class InformacaoNuitricionalConfig : IEntityTypeConfiguration<InformacaoNutricional>
	{
		public void Configure(EntityTypeBuilder<InformacaoNutricional> builder)
		{
			builder.DefineBasicConfigs(tableName: "info_nutricional");

			builder.HasOne(p => p.UnidadeMedida).WithMany(p => p.InformacoesNutricionais).HasForeignKey(p => p.UnidadeMedidaId);

			builder.HasOne(p => p.Receita).WithMany(p => p.InformacoesNutricionaisConsolidadas).HasForeignKey(p => p.ReceitaId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Property(p => p.Quantidade).HasColumnName("n_quantidade");
			builder.Property(p => p.UnidadeMedidaId).HasColumnName("id_unidade_medida");
			builder.Property(p => p.IngredienteId).HasColumnName("id_ingrediente");
		}
	}
}
