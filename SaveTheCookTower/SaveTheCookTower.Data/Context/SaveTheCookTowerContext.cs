using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaveTheCookTower.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaveTheCookTower.CrossCutting.Utils;

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

			modelBuilder.Entity<Usuario>().HasData(new Usuario
			{
				Email = "adm@adm.com",
				Login = "adm",
				Nome = "Administrador do sistema",
				Password = "123".ToHashMD5()
			});

			modelBuilder.Entity<Usuario>().HasData(new Usuario
			{
				Email = "teste@teste.com",
				Login = "string",
				Nome = "Usuário de testes com login string e senha string",
				Password = "string".ToHashMD5()
			});

			modelBuilder.Entity<UnidadeMedida>().HasData(new UnidadeMedida { Nome = "grama", NomeResumido = "g", 
				Sinonimos = "gramas,grama(g)", Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Massa});

			modelBuilder.Entity<UnidadeMedida>().HasData(new UnidadeMedida
			{
				Nome = "kilograma",
				NomeResumido = "kg",
				Sinonimos = "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Massa
			});

			modelBuilder.Entity<UnidadeMedida>().HasData(new UnidadeMedida
			{
				Nome = "metro",
				NomeResumido = "m",
				Sinonimos = "metros,metro(m)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Comprimento
			});

		}
	}
}
