using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Application.ViewModels
{
	public class ReceitaViewModel
	{
		public DateTime? CriadoEmUtc { get; set; }
		public DateTime? AtualizadoEmUtc { get; set; }
		public Guid? Id { get; set; }
		public string Nome { get; set; }
		public string Sinonimos { get; set; }
		public Uri ItemUri { get; set; }
		public bool ForaDeUso { get; set; }

		/// <summary>
		/// Lista das eventuais receitas filhas, como um molho ou cobertura
		/// </summary>
		public List<ReceitaViewModel> ReceitasFilhas { get; }
		/// <summary>
		/// Referencia ao objeto da receita pai
		/// </summary>
		public ReceitaViewModel? ReceitaPai { get; set; }
		/// <summary>
		/// Id da receita pai
		/// </summary>
		public Guid? ReceitaPaiId { get; set; }
		/// <summary>
		/// Idica a categoria da receita. Exemplo: Carnes, Massas, Sobremesas
		/// </summary>
		public CategoriaViewModel? Categoria { get; set; }

		/// <summary>
		/// Id da  categoria
		/// </summary>
		public Guid? CategoriaId { get; set; }

		public string NomeCategoria
		{
			get
			{
				return Categoria != null ? Categoria.Nome : "";
			}
		}

		/// <summary>
		/// Trata-se de uma breve descrição do alimento e da receita.
		/// Exemplo: Esse bolo de cenoura de liquidificador fica pronto em 
		/// menos de 1 hora leva apenas 20 minutos para a massa ser preparada.
		/// </summary>
		public String Descricao { get; set; }

		/// <summary>
		/// Tempo de preparo em minutos. *** Poderia ser mais adequado usar duas propriedades (quantidade e unidade de medida) ou DateTime ***s
		/// </summary>
		public int? TempoPreparoMinutos { get; set; }
		/// <summary>
		/// Indica quantas porções (equivalente a quantidade de pessoas que poderiam ser servidas) a receita faz.
		/// Esta informação deve ser levada em conta para calculos em si, como calorias ou igredientes.
		/// </summary>
		public int? RendimentoPorcoes { get; set; }
		/// <summary>
		/// Permite indicar a fonte da receita, ou seja, quem é seu autor. Para respeitaros remeditos e remeter até ao site de origem
		/// </summary>
		public FontePropriedadeIntelectualViewModel? Fonte { get; set; }
		/// <summary>
		/// Id da fonte
		/// </summary>
		public Guid? FonteId { get; set; }
		/// <summary>
		/// Descreve a avaliação geral (media) da receita
		/// </summary>
		public AvaliacaoDoUsuarioViewModel? AvaliacaoMedia { get; set; }
		public Guid? AvaliacaoMediaId { get; set; }
		/// <summary>
		/// Lista de todas as avaliações de usuários para a receita
		/// </summary>
		public List<AvaliacaoDoUsuarioViewModel> Avaliacoes { get; }
		/// <summary>
		/// Lista de todos os igredientes da receita. Se ela possuir receita filha, os igredientes devem ser acessados por ReceitasFilhas[].Ingredientes
		/// </summary>
		public List<ItemListaIngredientesViewModel> Ingredientes { get; }

		/// <summary>
		/// Para subir para o servidor o texto dos ingredientes inseridos como texto
		/// </summary>
		public string IngredientesAsStr { get; set; }

		/// <summary>
		/// Lista de todas as etapas para preparo dareceita. Se ela possuir receita filha, as etapas devem ser acessados por ReceitasFilhas[].Etapas
		/// </summary>
		public List<EtapaDePreparoViewModel> EstapasDePreparo { get; }

		/// <summary>
		/// Lista de Uris para acessar imagens da receita. A primeira poderia ser a de capa e as demais complementares
		/// Verificar se podeser um repositório estático ou um caminho apra consultar a api com GET
		/// </summary>
		public string ImagensUri { get; set; }
		/// <summary>
		/// Lista de Uris para acessar videos da receita.
		/// Verificar se podeser um repositório estático ou um caminho apra consultar a api com GET
		/// </summary>
		public string VideosUri { get; set; }

		/// <summary>
		/// Além de ter nos ingredientes do item de ingredientes tem o consolidado aqui as informações nutricuionais dos igredientes diretos da receita 
		/// e dos valores consolidados de todas as receitas filhas (que computam seus igredientes e de eventuais receitas filhas)
		/// </summary>
		public List<InformacaoNutricionalViewModel> InformacoesNutricionaisConsolidadas { get; }

	}
}
