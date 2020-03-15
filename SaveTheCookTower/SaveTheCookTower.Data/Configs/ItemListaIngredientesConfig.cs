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

			builder.HasOne(p => p.Receita).WithMany(p => p.Ingredientes).HasForeignKey(p => p.ReceitaId);

		}
	}
}
