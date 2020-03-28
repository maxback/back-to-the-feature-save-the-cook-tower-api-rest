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
	public class ReceitaAppService : IReceitaAppService
	{
		private readonly IServiceBase<Receita> _service;
		private readonly IMapper _mapper;

		public ReceitaAppService(IServiceBase<Receita> ReceitaService, IMapper mapper)
		{
			_service = ReceitaService;
			_mapper = mapper;

		}

		public ReceitaViewModel Add(ReceitaViewModel obj)
		{
			var modelObj = _mapper.Map<Receita>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<ReceitaViewModel>(modelObj);
		}

		public IList<ReceitaViewModel> Find(Expression<Func<ReceitaViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<Receita, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<ReceitaViewModel>>(modelObjs);
		}

		public IList<ReceitaViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<ReceitaViewModel>>(mdelObjs);
		}

		public ReceitaViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<ReceitaViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<ReceitaViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<Receita, bool>>>(predicate);

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

		public void Update(ReceitaViewModel obj)
		{
			var modelObj = _mapper.Map<Receita>(obj);

			_service.Update(modelObj);
		}
	}
}
