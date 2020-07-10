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
			
			builder.HasMany(p => p.ReceitasFilhas).WithOne(p => p.ReceitaPai).HasForeignKey(p => p.ReceitaPaiId);

			builder.HasOne(p => p.ReceitaPai).WithMany(p => p.ReceitasFilhas).HasForeignKey(p => p.ReceitaPaiId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(p => p.Categoria).WithMany(p => p.Receitas).HasForeignKey(p => p.CategoriaId);

			builder.HasOne(p => p.Fonte).WithMany(p => p.Receitas).HasForeignKey(p => p.FonteId);

			builder.HasOne(p => p.AvaliacaoMedia).WithOne(p => p.ReceitaDeQuemEhAvaliacaoMedia).HasForeignKey<AvaliacaoDoUsuario>(p => p.ReceitaDeQuemEhAvaliacaoMediaId);

			builder.HasMany(p => p.Avaliacoes).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);

			builder.HasMany(p => p.Ingredientes).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);

			builder.HasMany(p => p.EtapasDePreparo).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);

			builder.HasMany(p => p.InformacoesNutricionaisConsolidadas).WithOne(p => p.Receita).HasForeignKey(p => p.ReceitaId);

			builder.Property(p => p.ReceitaPaiId).HasColumnName("id_receita_pai");
			builder.Property(p => p.CategoriaId).HasColumnName("id_categoria");
			builder.Property(p => p.Descricao).HasColumnName("descricao");
			builder.Property(p => p.TempoPreparoMinutos).HasColumnName("n_tempo_preparo_minutos");
			builder.Property(p => p.RendimentoPorcoes).HasColumnName("n_redimento_porcoes");
			builder.Property(p => p.FonteId).HasColumnName("id_fonte");
			builder.Property(p => p.AvaliacaoMediaId).HasColumnName("id_avaliacao_media");
			builder.Property(p => p.ImagensUri).HasColumnName("m_imagens_url");
			builder.Property(p => p.VideosUri).HasColumnName("m_videos_url");

		}
	}
}
