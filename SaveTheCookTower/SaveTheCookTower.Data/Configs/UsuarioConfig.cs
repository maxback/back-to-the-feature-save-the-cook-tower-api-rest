using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Configs
{
	public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.DefineBasicConfigs(tableName: "usuario");

			builder.HasMany(p => p.AvaliacoesFeitasPeloUsuario).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId);

			builder.Property(p => p.Email).HasColumnName("s_email");
			builder.Property(p => p.Login).HasColumnName("s_login");
			builder.Property(p => p.Password).HasColumnName("s_password");
			builder.Property(p => p.Token).HasColumnName("s_token");

		}
	}
}
