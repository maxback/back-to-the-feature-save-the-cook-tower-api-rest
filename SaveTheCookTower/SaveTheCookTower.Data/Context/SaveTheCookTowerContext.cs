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

			var unidade = new UnidadeMedida
			{
				Nome = "unidade",
				NomeResumido = "un",
				Sinonimos = "unidades,unidade(un)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Unidades
			};
			modelBuilder.Entity<UnidadeMedida>().HasData(unidade);

			modelBuilder.Entity<UnidadeMedida>().HasData(new UnidadeMedida { Nome = "grama", NomeResumido = "g", 
				Sinonimos = "gramas,grama(g)", Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Massa});

			modelBuilder.Entity<UnidadeMedida>().HasData(new UnidadeMedida
			{
				Nome = "kilograma",
				NomeResumido = "kg",
				Sinonimos = "kilo,kilos,kilo gramas,kilogramas,kilograma(kg)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Massa
			});

			var l = new UnidadeMedida
			{
				Nome = "litro",
				NomeResumido = "l",
				Sinonimos = "litros,litro(l)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Volume
			};
			modelBuilder.Entity<UnidadeMedida>().HasData(l);


			var xic = new UnidadeMedida
			{
				Nome = "xícara de chá",
				NomeResumido = "xíc",
				Sinonimos = "xic,cicara de cha, xícara chá, xícaras de chá,xícara(chá)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Volume
			};
			modelBuilder.Entity<UnidadeMedida>().HasData(xic);


			var m = new UnidadeMedida
			{
				Nome = "metro",
				NomeResumido = "m",
				Sinonimos = "metros,metro(m)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Comprimento
			};
			modelBuilder.Entity<UnidadeMedida>().HasData(m);

			var mm = new UnidadeMedida
			{
				Nome = "milimetro",
				NomeResumido = "mm",
				Sinonimos = "milimetros,milimetro(ml)",
				Tipo = CrossCutting.Utils.Enumerations.TiposDeUnidadesDeMedida.Comprimento
			};


			modelBuilder.Entity<UnidadeMedida>().HasData(mm);


			modelBuilder.Entity<EquivalenciaEntreUnidadesDeMedida>().HasData(new EquivalenciaEntreUnidadesDeMedida
			{
				Nome = "metro para milimetros",
				OrigemId = m.Id,
				DestinoId = mm.Id,
				RazaoOrigemDestino = 1.0 / 1000.0,
				Sinonimos = "razão m/ml, metro para milimetros,m para ml"
			});

			modelBuilder.Entity<EquivalenciaEntreUnidadesDeMedida>().HasData(new EquivalenciaEntreUnidadesDeMedida
			{
				Nome = "xícaras de chá pra litros",
				OrigemId = xic.Id,
				DestinoId = l.Id,
				RazaoOrigemDestino = 250.0 / 1000.0,
				Sinonimos = "razão xíc/l, xícara de chá apra litros,xíc para l,xic para l"
			});

			var cp = new Categoria
			{
				Nome = "Categorias",
				Sinonimos = "Categoria Raiz",
				CategoriaPai = null
			};

			modelBuilder.Entity<Categoria>().HasData(cp);

			var cat_ing = new Categoria
			{
				Nome = "Ingredientes",
				Sinonimos = "Categoria Raiz dos Ingredientes",
				CategoriaPaiId = cp.Id
			};

			modelBuilder.Entity<Categoria>().HasData(cat_ing);

			var rec = new Categoria
			{
				Nome = "Receitas",
				Sinonimos = "Categoria Raiz das Receitas",
				CategoriaPaiId = cp.Id
			};

			modelBuilder.Entity<Categoria>().HasData(rec);

			modelBuilder.Entity<Categoria>().HasData(new Categoria
			{
				Nome = "Tortas",
				Sinonimos = "Categoria Raiz das tortas",
				CategoriaPaiId = rec.Id
			});

			var cat_cafe = new Categoria
			{
				Nome = "Café da manhã",
				Sinonimos = "Cafe da manha",
				CategoriaPaiId = rec.Id
			};

			modelBuilder.Entity<Categoria>().HasData(cat_cafe);

			modelBuilder.Entity<Categoria>().HasData(new Categoria
			{
				Nome = "Jantar",
				Sinonimos = "Categoria Raiz dos Jantares",
				CategoriaPaiId = rec.Id
			});

			var farinha = new Ingrediente
			{
				Nome = "Farinha de Trigo",
				CategoriaId = cat_ing.Id,
				Sinonimos = "Trigo"
			};
			modelBuilder.Entity<Ingrediente>().HasData(farinha);

			var fermento = new Ingrediente
			{
				Nome = "Fermento para Pão",
				CategoriaId = cat_ing.Id,
				Sinonimos = "Fermento biológico"
			};
			modelBuilder.Entity<Ingrediente>().HasData(fermento);

			var ovo = new Ingrediente
			{
				Nome = "Ovo de galinha",
				CategoriaId = cat_ing.Id,
				Sinonimos = "Ovo"
			};
			modelBuilder.Entity<Ingrediente>().HasData(ovo);

			var agua = new Ingrediente
			{
				Nome = "Água",
				CategoriaId = cat_ing.Id,
				Sinonimos = "Agua"
			};
			modelBuilder.Entity<Ingrediente>().HasData(agua);


			var rec1 = new Receita
			{
				Nome = "Pão de Forma",
				Sinonimos = "Pão assado,pao assado",
				ReceitaPaiId = null,
				TempoPreparoMinutos = 120,
				RendimentoPorcoes = 5,
				CategoriaId = cat_cafe.Id

			};
			modelBuilder.Entity<Receita>().HasData(rec1);

			var li1 = new ItemListaIngredientes { ReceitaId = rec1.Id, Nome = farinha.Nome, IngredienteId = farinha.Id, Ordem = 0, Quantidade = 3, UnidadeMedidaId = xic.Id };
			modelBuilder.Entity<ItemListaIngredientes>().HasData(li1);
			var li2 = new ItemListaIngredientes { ReceitaId = rec1.Id, Nome = farinha.Nome, IngredienteId = farinha.Id, Ordem = 0, Quantidade = 3, UnidadeMedidaId = xic.Id };
			modelBuilder.Entity<ItemListaIngredientes>().HasData(li2);
			var li3 = new ItemListaIngredientes { ReceitaId = rec1.Id, Nome = fermento.Nome, IngredienteId = fermento.Id, Ordem = 1, Quantidade = 1, UnidadeMedidaId = xic.Id };
			modelBuilder.Entity<ItemListaIngredientes>().HasData(li3);
			var li4 = new ItemListaIngredientes { ReceitaId = rec1.Id, Nome = ovo.Nome, IngredienteId = ovo.Id, Ordem = 2, Quantidade = 5, UnidadeMedidaId = unidade.Id };
			modelBuilder.Entity<ItemListaIngredientes>().HasData(li4);
			var li5 = new ItemListaIngredientes { ReceitaId = rec1.Id, Nome = agua.Nome, IngredienteId = agua.Id, Ordem = 3, Quantidade = 0.5, UnidadeMedidaId = l.Id };
			modelBuilder.Entity<ItemListaIngredientes>().HasData(li5);

			/*
			rec1.Ingredientes.Add(new ItemListaIngredientes {  });
			rec1.Ingredientes.Add(new ItemListaIngredientes {  });
			rec1.Ingredientes.Add(new ItemListaIngredientes {  });
			rec1.Ingredientes.Add(new ItemListaIngredientes {  });
			*/

		}
	}
}
