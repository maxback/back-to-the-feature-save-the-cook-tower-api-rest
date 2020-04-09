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
			entityTypeBuilder.Property(p => p.AtualizadoEmUtc).HasColumnName("dt_atualizacao").IsRequired();
			entityTypeBuilder.Property(p => p.AtualizadoPorId).HasColumnName("id_Usu_atualizacao");
			entityTypeBuilder.Property(p => p.CriadoEmUtc).HasColumnName("dt_criacao").IsRequired();
			entityTypeBuilder.Property(p => p.CriadoPorId).HasColumnName("id_usu_criacao");
			entityTypeBuilder.Property(p => p.ForaDeUso).HasColumnName("b_fora_uso").IsRequired();
			entityTypeBuilder.Property(p => p.ItemUri).HasColumnName("s_uri");
			entityTypeBuilder.Property(p => p.Nome).HasColumnName("s_nome").IsRequired();
			entityTypeBuilder.Property(p => p.Sinonimos).HasColumnName("m_sinonimos");
			entityTypeBuilder.Property(p => p.Id).HasColumnName("id").IsRequired();
		}

	}
}
