using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Domain.Models
{
	public class Receita: ModelBase
	{
		/// <summary>
		/// Lista das eventuais receitas filhas, como um molho ou cobertura
		/// </summary>
		public virtual List<Receita> ReceitasFilhas { get; set; }
		public virtual Categoria Categoria { get; set; }
		/// <summary>
		/// Trata-se de uam breve descrição do alimento e da receita.
		/// Exemplo: Esse bolo de cenoura de liquidificador fica pronto em 
		/// menos de 1 hora leva apenas 20 minutos para a massa ser preparada.
		/// </summary>
		public String Descricao { get; set; }
		public int? TempoPreparoMinutos { get; set; }
		public int? RendimentoPorcoes { get; set; }
		public virtual FontePropriedadeIntelectual Fonte { get; set; }
		/// <summary>
		/// Descreve a avaliação geral (media) da receita
		/// </summary>
		public virtual AvaliacaoDoUsuario AvaliacaoMedia { get; set; }
		public Guid AvaliacaoMediaId { get; set; }
		/// <summary>
		/// Lista de todas as avaliações de usuários para a receita
		/// </summary>
		public virtual List<AvaliacaoDoUsuario> Avaliacoes{ get; set; }
		public virtual List<ItemListaIngredientes> Ingredientes { get; set; }
		public virtual List<EtapaDePreparo> Etapas { get; set; }

		public virtual List<Uri> ImagensUri { get; set; }
		public virtual List<Uri> VideosUri { get; set; }

		/// <summary>
		/// Além de ter nos ingredientes do itme de ingredientes tem o consolidado aqui
		/// </summary>
		public virtual List<InformacaoNutricional> InformacaoNutricionalConsolidada { get; set; }
	}
}
