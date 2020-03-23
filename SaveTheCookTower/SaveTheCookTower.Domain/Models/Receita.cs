using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Domain.Models
{
	/// <summary>
	/// Modelo para uma receita, com categoria, receitas filhas e demais dados
	/// </summary>
	public class Receita: ModelBase
	{
		/// <summary>
		/// Lista das eventuais receitas filhas, como um molho ou cobertura
		/// </summary>
		public virtual List<Receita> ReceitasFilhas { get; }
		/// <summary>
		/// Referencia ao objeto da receita pai
		/// </summary>
		public virtual Receita ReceitaPai { get; set; }
		/// <summary>
		/// Id da receita pai
		/// </summary>
		public Guid? ReceitaPaiId { get; set; }
		/// <summary>
		/// Idica a categoria da receita. Exemplo: Carnes, Massas, Sobremesas
		/// </summary>
		public virtual Categoria Categoria { get; set; }

		/// <summary>
		/// Id da  categoria
		/// </summary>
		public Guid CategoriaId { get; set; }

		/// <summary>
		/// Trata-se de uma breve descrição do alimento e da receita.
		/// Exemplo: Esse bolo de cenoura de liquidificador fica pronto em 
		/// menos de 1 hora leva apenas 20 minutos para a massa ser preparada.
		/// </summary>
		public String Descricao { get; set; }

		/// <summary>
		/// Tem de preparo em minutos. *** Poderia ser mais adequado usar duas propriedades (quantidade e unidade de medida) ou DateTime ***s
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
		public virtual FontePropriedadeIntelectual Fonte { get; set; }
		/// <summary>
		/// Id da fonte
		/// </summary>
		public Guid FonteId { get; set; }
		/// <summary>
		/// Descreve a avaliação geral (media) da receita
		/// </summary>
		public virtual AvaliacaoDoUsuario AvaliacaoMedia { get; set; }
		public Guid AvaliacaoMediaId { get; set; }
		/// <summary>
		/// Lista de todas as avaliações de usuários para a receita
		/// </summary>
		public virtual List<AvaliacaoDoUsuario> Avaliacoes{ get; }
		/// <summary>
		/// Lista de todos os igredientes da receita. Se ela possuir receita filha, os igredientes devem ser acessados por ReceitasFilhas[].Ingredientes
		/// </summary>
		public virtual List<ItemListaIngredientes> Ingredientes { get; }
		/// <summary>
		/// Lista de todas as etapas para preparo dareceita. Se ela possuir receita filha, as etapas devem ser acessados por ReceitasFilhas[].Etapas
		/// </summary>
		public virtual List<EtapaDePreparo> EstapasDePreparo { get; }

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
		public virtual List<InformacaoNutricional> InformacoesNutricionaisConsolidadas { get; }
	}
}
