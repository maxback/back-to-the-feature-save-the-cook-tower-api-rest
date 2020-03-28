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
	public class UsuarioAppService : IUsuarioAppService
	{
		private readonly IServiceBase<Usuario> _service;
		private readonly IMapper _mapper;

		public UsuarioAppService(IServiceBase<Usuario> UsuarioService, IMapper mapper)
		{
			_service = UsuarioService;
			_mapper = mapper;

		}

		public UsuarioViewModel Add(UsuarioViewModel obj)
		{
			var modelObj = _mapper.Map<Usuario>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<UsuarioViewModel>(modelObj);
		}

		public IList<UsuarioViewModel> Find(Expression<Func<UsuarioViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<Usuario, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<UsuarioViewModel>>(modelObjs);
		}

		public IList<UsuarioViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<UsuarioViewModel>>(mdelObjs);
		}

		public UsuarioViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<UsuarioViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<UsuarioViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<Usuario, bool>>>(predicate);

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

		public void Update(UsuarioViewModel obj)
		{
			var modelObj = _mapper.Map<Usuario>(obj);

			_service.Update(modelObj);
		}
	}
}
