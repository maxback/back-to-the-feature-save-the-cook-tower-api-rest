using System;
using System.Collections.Generic;
using System.Text;

namespace SaveTheCookTower.Domain.Interfaces.Base
{
	public interface IRepositoryBase<TModel> where TModel : class
	{
		/// <summary>
		/// Adiciona objeto ao repositório
		/// </summary>
		/// <param name="obj">Objeto com todos os dados a serem incluidos</param>
		/// <returns></returns>
		TModel Add(TModel obj);

		/// <summary>
		/// Atualiza objeto norepositório
		/// </summary>
		/// <param name="obj">Objeto com dados editado</param>
		void Update(TModel obj);

		/// <summary>
		/// Remove o bjeto com o id 
		/// </summary>
		/// <param name="id">guid de id do objeto</param>
		void Remove(Guid id);

		/// <summary>
		/// Retorna um objeto do reposítório correspodnente ao id passado
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		TModel GetById(Guid id);

		/// <summary>
		/// Retorna todos os objetos.
		/// </summary>
		/// <returns></returns>
		IList<TModel> GetAll();

		/// <summary>
		/// Procura os objetos correspondetes ao predicado.
		/// </summary>
		/// <param name="predicate">predicado (lambda de pesquisa como no LINQ)</param>
		/// <param name="fromIndex">Índice inicial do resultado. Se definido indica o offset do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <param name="toIndex">Índice final do resultado. Se definido indica o final do inicio subgrupo do resultado de predicado que deve resultar</param>
		/// <returns></returns>
		IList<TModel> Find(Func<TModel, bool> predicate, int? fromIndex, int?toIndex);

		/// <summary>
		/// Retorna a quantidade de objetos correspondente ao predicado
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int GetCount(Func<TModel, bool> predicate);

		/// <summary>
		/// Retorna a quantidade de objetos
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int GetCount();
	}
}
