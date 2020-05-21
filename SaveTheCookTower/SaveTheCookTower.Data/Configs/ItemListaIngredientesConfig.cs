using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class ItemListaIngredientesConfig : IEntityTypeConfiguration<ItemListaIngredientes>
	{
		public void Configure(EntityTypeBuilder<ItemListaIngredientes> builder)
		{
			builder.DefineBasicConfigs(tableName: "item_lista_ingrediente");

			builder.HasOne(p => p.UnidadeMedida).WithMany(p => p.ItensListaIngredientes).HasForeignKey(p => p.UnidadeMedidaId);

			builder.HasOne(p => p.Ingrediente).WithMany(p => p.ItensListaIngredientes).HasForeignKey(p => p.IngredienteId);

			builder.HasOne(p => p.Receita).WithMany(p => p.Ingredientes).HasForeignKey(p => p.ReceitaId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Property(p => p.Ordem).HasColumnName("n_ordem");
			builder.Property(p => p.Quantidade).HasColumnName("n_quantidade");
			builder.Property(p => p.UnidadeMedidaId).HasColumnName("id_unidade_medida");
			builder.Property(p => p.IngredienteId).HasColumnName("id_ingrediente");
			builder.Property(p => p.ReceitaId).HasColumnName("id_receia");
		}
	}
}
