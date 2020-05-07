using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class ItemCardapioConfig : IEntityTypeConfiguration<ItemCardapio>
	{
		public void Configure(EntityTypeBuilder<ItemCardapio> builder)
		{
			builder.DefineBasicConfigs(tableName: "item_cardapio");


			builder.HasMany(p => p.Receitas).WithOne(p => p.ItemCardapio).HasForeignKey(p => p.ItemCardapioId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.Cardapio).WithMany(p => p.Itens).HasForeignKey(p => p.CardapioId);

			builder.Property(p => p.Semana).HasColumnName("n_semana");
			builder.Property(p => p.DiaDaSemana).HasColumnName("n_dia_da_semana");
			builder.Property(p => p.Porcoes).HasColumnName("n_porcoes");
		}
	}
}
