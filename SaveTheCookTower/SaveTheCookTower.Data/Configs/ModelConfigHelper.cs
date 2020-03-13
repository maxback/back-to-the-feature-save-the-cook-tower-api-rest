using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models.Base;

namespace SaveTheCookTower.Data.Configs
{
	public static class ModelConfigHelper
	{
		public static void DefineBasicConfigs<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, string tableName) where TEntity : ModelBase
		{
			entityTypeBuilder.ToTable(tableName);
			entityTypeBuilder.HasKey(p => p.Id);
			entityTypeBuilder.Property(p => p.AtualizadoEmUtc).HasColumnName("dt_atualizacao").IsRequired();
			entityTypeBuilder.Property(p => p.AtualizadoPor).HasColumnName("id_user_atualizacao").IsRequired();
			entityTypeBuilder.Property(p => p.CriadoEmUtc).HasColumnName("dt_criacao").IsRequired();
			entityTypeBuilder.Property(p => p.CriadoPor).HasColumnName("id_user_criacao").IsRequired();
			entityTypeBuilder.Property(p => p.ForaDeUso).HasColumnName("fl_fora_uso").IsRequired();
			entityTypeBuilder.Property(p => p.ItemUri).HasColumnName("s_uri").IsRequired();
			entityTypeBuilder.Property(p => p.Nome).HasColumnName("s_nome").IsRequired();
			entityTypeBuilder.Property(p => p.Sinonimos).HasColumnName("m_sinonimos");
			entityTypeBuilder.Property(p => p.Id).HasColumnName("guid_id").IsRequired();
		}

	}
}
