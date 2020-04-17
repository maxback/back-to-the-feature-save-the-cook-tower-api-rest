using AutoMapper;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SaveTheCookTower.Application.ApplicationServices
{
	public class ItemListaIngredientesAppServiceAppService : IItemListaIngredientesAppService
	{
		private readonly IServiceBase<ItemListaIngredientes> _service;
		private readonly IMapper _mapper;

		public ItemListaIngredientesAppServiceAppService(IServiceBase<ItemListaIngredientes> IngredienteService, IMapper mapper)
		{
			_service = IngredienteService;
			_mapper = mapper;

		}

		public ItemListaIngredientesViewModel Add(ItemListaIngredientesViewModel obj)
		{
			var modelObj = _mapper.Map<ItemListaIngredientes>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<ItemListaIngredientesViewModel>(modelObj);
		}


		public IList<ItemListaIngredientesViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<ItemListaIngredientes> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))
				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<ItemListaIngredientesViewModel>>(modelObjs);

		}

		public IList<ItemListaIngredientesViewModel> Find(Expression<Func<ItemListaIngredientesViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemListaIngredientes, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<ItemListaIngredientesViewModel>>(modelObjs);
		}

		public IList<ItemListaIngredientesViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<ItemListaIngredientesViewModel>>(mdelObjs);
		}

		public ItemListaIngredientesViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<ItemListaIngredientesViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<ItemListaIngredientesViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemListaIngredientes, bool>>>(predicate);

			return _service.GetCount(newPredicate);
		}

		public int GetCount()
		{
			return _service.GetCount();
		}

		public void Remove(Guid id)
		{
			_service.Remove(id);
		}

		public void Update(ItemListaIngredientesViewModel obj)
		{
			var modelObj = _mapper.Map<ItemListaIngredientes>(obj);

			_service.Update(modelObj);
		}
	}
}
