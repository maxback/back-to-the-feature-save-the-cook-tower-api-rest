using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Data.Configs
{
	/// <summary>
	/// Classe de helper para fluent api de configuração dos modelos do EF
	/// </summary>
	public static class ModelConfigHelper
	{
		public static void DefineBasicConfigs<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, string tableName) where TEntity : ModelBase
		{
			entityTypeBuilder.ToTable(tableName);
			entityTypeBuilder.HasKey(p => p.Id);
			entityTypeBuilder.Property(p => p.AtualizadoEmUtc).HasColumnName("dtAtualizacao").IsRequired();
			entityTypeBuilder.Property(p => p.AtualizadoPor).HasColumnName("idUsuAtualizacao").IsRequired();
			entityTypeBuilder.Property(p => p.CriadoEmUtc).HasColumnName("dtCriacao").IsRequired();
			entityTypeBuilder.Property(p => p.CriadoPor).HasColumnName("idUsuCriacao").IsRequired();
			entityTypeBuilder.Property(p => p.ForaDeUso).HasColumnName("bForaUso").IsRequired();
			entityTypeBuilder.Property(p => p.ItemUri).HasColumnName("sUri").IsRequired();
			entityTypeBuilder.Property(p => p.Nome).HasColumnName("sNome").IsRequired();
			entityTypeBuilder.Property(p => p.Sinonimos).HasColumnName("mSinonimos");
			entityTypeBuilder.Property(p => p.Id).HasColumnName("id").IsRequired();
		}

	}
}
