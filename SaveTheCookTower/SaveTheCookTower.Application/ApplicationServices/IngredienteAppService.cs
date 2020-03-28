using AutoMapper;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SaveTheCookTower.Application.ApplicationServices
{
	public class IngredienteAppService : IIngredienteAppService
	{
		private readonly IServiceBase<Ingrediente> _service;
		private readonly IMapper _mapper;

		public IngredienteAppService(IServiceBase<Ingrediente> IngredienteService, IMapper mapper)
		{
			_service = IngredienteService;
			_mapper = mapper;

		}

		public IngredienteViewModel Add(IngredienteViewModel obj)
		{
			var modelObj = _mapper.Map<Ingrediente>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<IngredienteViewModel>(modelObj);
		}

		public IList<IngredienteViewModel> Find(Expression<Func<IngredienteViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<Ingrediente, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<IngredienteViewModel>>(modelObjs);
		}

		public IList<IngredienteViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<IngredienteViewModel>>(mdelObjs);
		}

		public IngredienteViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<IngredienteViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<IngredienteViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<Ingrediente, bool>>>(predicate);

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

		public void Update(IngredienteViewModel obj)
		{
			var modelObj = _mapper.Map<Ingrediente>(obj);

			_service.Update(modelObj);
		}
	}
}
