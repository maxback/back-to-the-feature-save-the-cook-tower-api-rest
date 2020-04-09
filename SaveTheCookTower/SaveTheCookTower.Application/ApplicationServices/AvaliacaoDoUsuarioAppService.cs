using AutoMapper;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SaveTheCookTower.Application.ApplicationServices
{
	public class AvaliacaoDoUsuarioAppService : IAvaliacaoDoUsuarioAppService
	{
		private readonly IServiceBase<AvaliacaoDoUsuario> _service;
		private readonly IMapper _mapper;

		public AvaliacaoDoUsuarioAppService(IServiceBase<AvaliacaoDoUsuario> avaliacaoDoUsuarioService, IMapper mapper)
		{
			_service = avaliacaoDoUsuarioService;
			_mapper = mapper;

		}
		public AvaliacaoDoUsuarioViewModel Add(AvaliacaoDoUsuarioViewModel obj)
		{
			var modelObj = _mapper.Map<AvaliacaoDoUsuario>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<AvaliacaoDoUsuarioViewModel>(modelObj);
		}

		public IList<AvaliacaoDoUsuarioViewModel> Find(Expression<Func<AvaliacaoDoUsuarioViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map < Expression<Func<AvaliacaoDoUsuario, bool>> > (predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<AvaliacaoDoUsuarioViewModel>>(modelObjs);
		}

		public IList<AvaliacaoDoUsuarioViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<AvaliacaoDoUsuarioViewModel>>(mdelObjs);
		}

		public AvaliacaoDoUsuarioViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<AvaliacaoDoUsuarioViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<AvaliacaoDoUsuarioViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<AvaliacaoDoUsuario, bool>>>(predicate);

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

		public void Update(AvaliacaoDoUsuarioViewModel obj)
		{
			var modelObj = _mapper.Map<AvaliacaoDoUsuario>(obj);

			_service.Update(modelObj);
		}
	}
}
