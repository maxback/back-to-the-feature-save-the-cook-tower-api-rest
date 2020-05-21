using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SaveTheCookTower.Application.XUnitTests.mocks
{
	public class MockServiceBase<TModel> : IServiceBase<TModel> where TModel : ModelBase
	{
		public MockServiceBase()
		{
			Model = new List<TModel>();
		}
		public List<TModel> Model { get; set; }
		public TModel Add(TModel obj)
		{
			throw new NotImplementedException();
		}

		public IList<TModel> Find(Expression<Func<TModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			int from = fromIndex ?? -1;
			int to = toIndex ?? -1;

			var result = new List<TModel>();

			if ((to < 0) || (from < 0) | (to < from))
			{
				result = Model.AsQueryable().Where(predicate).ToList();
				return result;
			}

			result = Model.AsQueryable().Where(predicate).Take(to + 1).Skip(from).ToList();
			return result;
		}

		public IList<TModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public TModel GetById(Guid id)
		{
			return Model.AsQueryable().Where(p => p.Id == id).ToList().FirstOrDefault();
		}

		public int GetCount(Expression<Func<TModel, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public int GetCount()
		{
			throw new NotImplementedException();
		}

		public void Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Update(TModel obj)
		{
			throw new NotImplementedException();
		}
	}
}
