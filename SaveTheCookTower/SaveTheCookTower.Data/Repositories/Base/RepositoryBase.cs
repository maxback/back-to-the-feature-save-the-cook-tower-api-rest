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
			obj.IncializarNovoObjeto();

			_context.Set<TModel>().Add(obj);
			_context.SaveChanges();

			return obj;
		}

		protected virtual int DoFind(out IList<TModel> result, Expression<Func<TModel, bool>> predicate, int? fromIndex = 0, int? toIndex = 0, bool onlyCount = false)
		{
			int skip = fromIndex.GetValueOrDefault();
			int take = toIndex.GetValueOrDefault() - skip;

			result = new List<TModel>();

			if (take <= 0)
			{
				if (onlyCount)
				{
					return _context.Set<TModel>().Where(predicate).ToList().Count();
				}
				else
				{
					result = _context.Set<TModel>().Where(predicate).ToList();
					return result.Count();
				}
			}

			take += 1;

			if (onlyCount)
			{
				return _context.Set<TModel>().Where(predicate).Take(take).Skip(skip).ToList().Count();
			}
			else
			{
				result = _context.Set<TModel>().Where(predicate).Take(take).Skip(skip).ToList();
				return result.Count();
			}
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
