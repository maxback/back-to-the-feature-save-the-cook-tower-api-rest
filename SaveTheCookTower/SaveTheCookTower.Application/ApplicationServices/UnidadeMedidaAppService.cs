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
	public class UnidadeMedidaAppService : IUnidadeMedidaAppService
	{
		private readonly IServiceBase<UnidadeMedida> _service;
		private readonly IMapper _mapper;


		public UnidadeMedidaAppService(IServiceBase<UnidadeMedida> UnidadeMedidaService, IMapper mapper)
		{
			_service = UnidadeMedidaService;
			_mapper = mapper;

		}

		public UnidadeMedidaViewModel Add(UnidadeMedidaViewModel obj)
		{
			var modelObj = _mapper.Map<UnidadeMedida>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<UnidadeMedidaViewModel>(modelObj);
		}

		public IList<UnidadeMedidaViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<UnidadeMedida> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))
				   || (p.NomeResumido.ToLower().Contains(text.ToLower()))
				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<UnidadeMedidaViewModel>>(modelObjs);
		}


		public IList<UnidadeMedidaViewModel> Find(Expression<Func<UnidadeMedidaViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<UnidadeMedida, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<UnidadeMedidaViewModel>>(modelObjs);
		}

		public IList<UnidadeMedidaViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<UnidadeMedida> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai) &&
				   (
				     (p.Nome.ToLower().Contains(text.ToLower()))
				     || (p.NomeResumido.ToLower().Contains(text.ToLower()))
				     || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<UnidadeMedidaViewModel>>(modelObjs);
		}

		public IList<UnidadeMedidaViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<UnidadeMedidaViewModel>>(mdelObjs);
		}

		public UnidadeMedidaViewModel GetById(Guid id)
		{
			var modelObj = _service.GetById(id);

			return _mapper.Map<UnidadeMedidaViewModel>(modelObj);
		}

		public int GetCount(Expression<Func<UnidadeMedidaViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<UnidadeMedida, bool>>>(predicate);

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

		public void Update(UnidadeMedidaViewModel obj)
		{
			var modelObj = _mapper.Map<UnidadeMedida>(obj);

			_service.Update(modelObj);
		}

		void IAppServiceBase<UnidadeMedidaViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
