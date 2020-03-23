using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;

namespace SaveTheCookTower.Data.Configs
{
	public class FontePropriedadeIntelectualConfig : IEntityTypeConfiguration<FontePropriedadeIntelectual>
	{
		public void Configure(EntityTypeBuilder<FontePropriedadeIntelectual> builder)
		{
			builder.DefineBasicConfigs(tableName: "fonte_prop_intelec");

			builder.HasMany(p => p.Receitas).WithOne(p => p.Fonte).HasForeignKey(p => p.FonteId);

			builder.Property(p => p.Autor).HasColumnName("s_autor");
			builder.Property(p => p.Titulo).HasColumnName("s_titulo");
			builder.Property(p => p.PaginaDoLivro).HasColumnName("n_pagina_livro");
			builder.Property(p => p.EdicaoDoLivro).HasColumnName("s_edicao_livro");
			builder.Property(p => p.OrigemUri).HasColumnName("uri_origem");
			builder.Property(p => p.AcessoEmUtc).HasColumnName("dt_acesso");
			builder.Property(p => p.Comentario).HasColumnName("m_comentario");

		}
	}
}
