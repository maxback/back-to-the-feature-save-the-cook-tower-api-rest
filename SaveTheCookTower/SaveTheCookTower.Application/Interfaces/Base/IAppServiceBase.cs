﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SaveTheCookTower.Application.Interfaces.Base
{
	public interface IAppServiceBase<TViewTModel> where TViewTModel : class
	{
		/// <summary>
		/// Adiciona objeto ao repositório
		/// </summary>
		/// <param name="obj">Objeto com todos os dados a serem incluidos</param>
		/// <returns></returns>
		TViewTModel Add(TViewTModel obj);

		/// <summary>
		/// Atualiza objeto norepositório
		/// </summary>
		/// <param name="obj">Objeto com dados editado</param>
		void Update(TViewTModel obj);

		/// <summary>
		/// Remove o bjeto com o id 
		/// </summary>
		/// <param name="id">guid de id do objeto</param>
		void Remove(Guid id);

		/// <summary>
		/// Procura os objetos do model que são filhos do pai passado em idPai, correspondetes ao predicado por texto, independente da propriedade do objeto e remove-os.
		/// </summary>
		/// <param name="idPai">Id do pai
		/// <param name="text">texto para procura
		/// <param name="fromIndex">Índice inicial do resultado. Se definido indica o offset do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <param name="toIndex">Índice final do resultado. Se definido indica o final do inicio subgrupo do resultado de predicado que deve resultar</param>
		void RemoveChildrenOf(Guid idPai, string text, int? from, int? to);

		/// <summary>
		/// Retorna um objeto do reposítório correspodnente ao id passado
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TViewTModel GetById(Guid id);

		/// <summary>
		/// Retorna todos os objetos.
		/// </summary>
		/// <returns></returns>
		IList<TViewTModel> GetAll();

		/// <summary>
		/// Procura os objetos correspondetes ao predicado por texto, independente da propriedade do objeto.
		/// </summary>
		/// <param name="text">texto para procura
		/// <param name="fromIndex">Índice inicial do resultado. Se definido indica o offset do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <param name="toIndex">Índice final do resultado. Se definido indica o final do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <returns></returns>
		IList<TViewTModel> Find(string text, int? fromIndex = null, int? toIndex = null);

		/// <summary>
		/// Procura os objetos do model que são filhos do pai passado em idPai, correspondetes ao predicado por texto, independente da propriedade do objeto.
		/// </summary>
		/// <param name="idPai">Id do pai
		/// <param name="text">texto para procura
		/// <param name="fromIndex">Índice inicial do resultado. Se definido indica o offset do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <param name="toIndex">Índice final do resultado. Se definido indica o final do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <returns></returns>
		IList<TViewTModel> FindChildrenOf(Guid idPai, string text, int? from, int? to);

		/// <summary>
		/// Procura os objetos correspondetes ao predicado.
		/// </summary>
		/// <param name="predicate">predicado (lambda de pesquisa como no LINQ)</param>
		/// <param name="fromIndex">Índice inicial do resultado. Se definido indica o offset do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <param name="toIndex">Índice final do resultado. Se definido indica o final do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <returns></returns>
		IList<TViewTModel> Find(Expression<Func<TViewTModel, bool>> predicate, int? fromIndex = null, int? toIndex = null);

		/// <summary>
		/// Retorna a quantidade de objetos correspondente ao predicado
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int GetCount(Expression<Func<TViewTModel, bool>> predicate);

		/// <summary>
		/// Retorna a quantidade de objetos
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int GetCount();

	}
}
