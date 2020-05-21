using SaveTheCookTower.Data.Context;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaveTheCookTower.CrossCutting.Utils;
using Microsoft.Extensions.Localization;

namespace SaveTheCookTower.Data.Repositories.Base
{
	public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : ModelBase
	{
		protected readonly SaveTheCookTowerContext _context;
		protected readonly IStringLocalizer<SharedResource> _localizer;

		public RepositoryBase(SaveTheCookTowerContext context, IStringLocalizer<SharedResource> localizer)
		{
			_context = context;
			_localizer = localizer;
		}

		public TModel Add(TModel obj)
		{

			obj.IncializarNovoObjeto(obj.Id == null);

			_context.Set<TModel>().Add(obj);
			_context.SaveChanges();

			return obj;
		}

		protected virtual int DoFind(out IList<TModel> result, Expression<Func<TModel, bool>> predicate, int? fromIndex = -1, int? toIndex = -1, bool onlyCount = false)
		{
			int from = fromIndex ?? -1;
			int to = toIndex ?? -1;

			result = new List<TModel>();

			if (onlyCount)
			{
				return _context.Set<TModel>().Where(predicate).ToList().Count();
			}
			else if ( (to < 0) || (from < 0) | (to < from))
			{
				result = _context.Set<TModel>().Where(predicate).ToList();
				return result.Count();
			}

			result = _context.Set<TModel>().Where(predicate).Take(to+1).Skip(from).ToList();
			return result.Count();
		}

		public IList<TModel> Find(Expression<Func<TModel, bool>> predicate, int? fromIndex = 0, int? toIndex = 0)
		{
			IList<TModel> result;

			DoFind(out result, predicate, fromIndex, toIndex, onlyCount: false);

			return result;
		}

		public IList<TModel> GetAll()
		{
			return _context.Set<TModel>().ToList();
		}

		public TModel GetById(Guid id)
		{
			return _context.Set<TModel>().FirstOrDefault(p => p.Id == id);
		}

		public int GetCount(Expression<Func<TModel, bool>> predicate)
		{
			IList<TModel> result;

			return DoFind(out result, predicate, onlyCount: true);
		}


		public int GetCount()
		{
			IList<TModel> result;

			return DoFind(out result, (p => true), onlyCount: true);
		}


		public void Remove(Guid id)
		{
			var obj = this.GetById(id);
			if (obj == null)
			{
				string s = _localizer["Objeto não localizado para excluir {0}", id].Value;
				throw new Exception(s);
			}
			_context.Set<TModel>().Remove(obj);
			_context.SaveChanges();
		}

		public void Update(TModel obj)
		{
			_context.Set<TModel>().Update(obj);
			_context.SaveChanges();
		}
	}
}
