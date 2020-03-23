using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class EquivalenciaEntreUnidadesDeMedidaConfig : IEntityTypeConfiguration<EquivalenciaEntreUnidadesDeMedida>
	{
		public void Configure(EntityTypeBuilder<EquivalenciaEntreUnidadesDeMedida> builder)
		{
			builder.DefineBasicConfigs(tableName: "unidade_medida_equiv");

			builder.HasOne(p => p.Origem).WithMany(p => p.EquivalenciasOrigem).HasForeignKey(p => p.OrigemId);

			builder.HasOne(p => p.Destino).WithMany(p => p.EquivalenciasDestino).HasForeignKey(p => p.DestinoId);

			builder.Property(p => p.OrigemId).HasColumnName("id_unidade_orig");
			builder.Property(p => p.DestinoId).HasColumnName("id_unidade_dest");
			builder.Property(p => p.RazaoDestinoOrigem).HasColumnName("nu_razao_orig_dest");

			builder.Ignore(p => p.RazaoOrigemDestino);

		}
	}
}
