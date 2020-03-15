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
		}
	}
}
