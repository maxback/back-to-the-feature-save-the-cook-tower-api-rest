using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class ReceitaConfig : IEntityTypeConfiguration<Receita>
	{
		public void Configure(EntityTypeBuilder<Receita> builder)
		{
			builder.DefineBasicConfigs(tableName: "receita");
			
			builder.Property(p => p.Descricao).HasColumnName("descricao");
			builder.Property(p => p.TempoPreparoMinutos).HasColumnName("tempo_preparo_minutos");
			builder.Property(p => p.RendimentoPorcoes).HasColumnName("redimento_porcoes");



			builder.HasMany(p => p.ReceitasFilhas).WithOne(p => p.ReceitaPai).HasForeignKey(p => p.ReceitaPaiId);
			builder.HasOne(p => p.ReceitaPai).WithMany(p => p.ReceitasFilhas).HasForeignKey(p => p.ReceitaPaiId);

			builder.HasOne(p => p.Categoria).WithMany(p => p.Receitas).HasForeignKey(p => p.CategoriaId);

			builder.HasMany(p => p.Ingredientes).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);

			builder.HasOne(p => p.Fonte).WithMany(p => p.Receitas).HasForeignKey(p => p.FonteId);

			builder.HasMany(p => p.Avaliacoes).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);
			builder.HasOne(p => p.AvaliacaoMedia).WithOne(p => p.Receita).HasForeignKey<AvaliacaoDoUsuario>(p => p.ReceitaId);
		}
	}
}
