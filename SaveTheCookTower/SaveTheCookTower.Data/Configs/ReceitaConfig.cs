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
		}
	}
}
