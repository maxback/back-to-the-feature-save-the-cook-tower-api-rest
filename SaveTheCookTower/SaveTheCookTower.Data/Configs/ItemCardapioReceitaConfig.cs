using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class ItemCardapioReceitaConfig : IEntityTypeConfiguration<ItemCardapioReceita>
	{
		public void Configure(EntityTypeBuilder<ItemCardapioReceita> builder)
		{
			builder.DefineBasicConfigs(tableName: "item_cardapio_receita");


			builder.HasOne(p => p.ItemCardapio).WithMany(p => p.ItensCardapioReceita).HasForeignKey(p => p.ItemCardapioId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.Receita).WithMany(p => p.ItensCardapioReceita).HasForeignKey(p => p.ReceitaId);
		}
	}
}
