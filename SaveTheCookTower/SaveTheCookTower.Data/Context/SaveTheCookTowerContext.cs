﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Data.Context
{
	public class SaveTheCookTowerContext: DbContext
	{
		private readonly IConfiguration _configuration;

		public SaveTheCookTowerContext(DbContextOptions options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		public DbSet<AvaliacaoDoUsuario> AvaliacoesDosUsuarios { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<EquivalenciaEntreUnidadesDeMedida> EquivalenciasEntreUnidadesDeMedida { get; set; }
		public DbSet<EtapaDePreparo> EtapasDePreparo { get; set; }
		public DbSet<FontePropriedadeIntelectual> FontesPropriedadeIntelectual { get; set; }
		public DbSet<InformacaoNutricional> InformacoesNutricionais { get; set; }
		public DbSet<Ingrediente> Ingredientes { get; set; }
		public DbSet<ItemListaIngredientes> ItensListaIngredientes { get; set; }
		public DbSet<Receita> Receitas { get; set; }
		public DbSet<UnidadeMedida> UnidadesMedida { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaveTheCookTowerContext).Assembly);

		}
	}
}