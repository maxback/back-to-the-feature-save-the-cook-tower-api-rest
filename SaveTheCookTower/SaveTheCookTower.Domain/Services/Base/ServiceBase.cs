using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SaveTheCookTower.Domain.Services.Base
{
	public class ServiceBase<TModel> : IServiceBase<TModel> where TModel : ModelBase
	{
		protected readonly IRepositoryBase<TModel> _repositoryBase;

		public ServiceBase(IRepositoryBase<TModel> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}
		public TModel Add(TModel obj)
		{
			return _repositoryBase.Add(obj);
		}

		public IList<TModel> Find(Expression<Func<TModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			return _repositoryBase.Find(predicate, fromIndex, toIndex);
		}

		public IList<TModel> GetAll()
		{
			return _repositoryBase.GetAll();
		}

		public TModel GetById(Guid id)
		{
			return _repositoryBase.GetById(id);
		}

		public int GetCount(Expression<Func<TModel, bool>> predicate)
		{
			return _repositoryBase.GetCount(predicate);
		}

		public int GetCount()
		{
			return _repositoryBase.GetCount();
		}

		public void Remove(Guid id)
		{
			_repositoryBase.Remove(id);
		}

		public void Update(TModel obj)
		{
			_repositoryBase.Update(obj);
		}
	}
}
