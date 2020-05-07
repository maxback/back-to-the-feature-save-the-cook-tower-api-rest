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
	public class EquivalenciaEntreUnidadesDeMedidaAppService : IEquivalenciaEntreUnidadesDeMedidaAppService
	{
		private readonly IServiceBase<EquivalenciaEntreUnidadesDeMedida> _service;
		private readonly IMapper _mapper;

		public EquivalenciaEntreUnidadesDeMedidaAppService(IServiceBase<EquivalenciaEntreUnidadesDeMedida> equivalenciaEntreUnidadesDeMedidaService, IMapper mapper)
		{
			_service = equivalenciaEntreUnidadesDeMedidaService;
			_mapper = mapper;

		}

		public EquivalenciaEntreUnidadesDeMedidaViewModel Add(EquivalenciaEntreUnidadesDeMedidaViewModel obj)
		{
			var modelObj = _mapper.Map<EquivalenciaEntreUnidadesDeMedida>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<EquivalenciaEntreUnidadesDeMedidaViewModel>(modelObj);
		}

		public IList<EquivalenciaEntreUnidadesDeMedidaViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<EquivalenciaEntreUnidadesDeMedida> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))

				   || (p.Origem.Id.ToString().ToLower().Contains(text.ToLower()))
				   || (p.Origem.Nome.ToLower().Contains(text.ToLower()))
				   || (p.Origem.NomeResumido.ToLower().Contains(text.ToLower()))
				   || (p.Origem.Sinonimos.ToLower().Contains(text.ToLower()))

				   || (p.Destino.Id.ToString().ToLower().Contains(text.ToLower()))
				   || (p.Destino.Nome.ToLower().Contains(text.ToLower()))
				   || (p.Destino.NomeResumido.ToLower().Contains(text.ToLower()))
				   || (p.Destino.Sinonimos.ToLower().Contains(text.ToLower()))

				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<EquivalenciaEntreUnidadesDeMedidaViewModel>>(modelObjs);

		}

		public IList<EquivalenciaEntreUnidadesDeMedidaViewModel> Find(Expression<Func<EquivalenciaEntreUnidadesDeMedidaViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<EquivalenciaEntreUnidadesDeMedida, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<EquivalenciaEntreUnidadesDeMedidaViewModel>>(modelObjs);
		}

		public IList<EquivalenciaEntreUnidadesDeMedidaViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<EquivalenciaEntreUnidadesDeMedida> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.DestinoId == idPai || p.OrigemId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => 
				   (p.CriadoPorId == idPai || p.DestinoId == idPai || p.OrigemId == idPai) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))

					   || (p.Origem.Id.ToString().ToLower().Contains(text.ToLower()))
					   || (p.Origem.Nome.ToLower().Contains(text.ToLower()))
					   || (p.Origem.NomeResumido.ToLower().Contains(text.ToLower()))
					   || (p.Origem.Sinonimos.ToLower().Contains(text.ToLower()))

					   || (p.Destino.Id.ToString().ToLower().Contains(text.ToLower()))
					   || (p.Destino.Nome.ToLower().Contains(text.ToLower()))
					   || (p.Destino.NomeResumido.ToLower().Contains(text.ToLower()))
					   || (p.Destino.Sinonimos.ToLower().Contains(text.ToLower()))

					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
					)
				   , from, to);
			}
			return _mapper.Map<List<EquivalenciaEntreUnidadesDeMedidaViewModel>>(modelObjs);

		}

		public IList<EquivalenciaEntreUnidadesDeMedidaViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<EquivalenciaEntreUnidadesDeMedidaViewModel>>(mdelObjs);
		}

		public EquivalenciaEntreUnidadesDeMedidaViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<EquivalenciaEntreUnidadesDeMedidaViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<EquivalenciaEntreUnidadesDeMedidaViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<EquivalenciaEntreUnidadesDeMedida, bool>>>(predicate);

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

		public void Update(EquivalenciaEntreUnidadesDeMedidaViewModel obj)
		{
			var modelObj = _mapper.Map<EquivalenciaEntreUnidadesDeMedida>(obj);

			_service.Update(modelObj);
		}
	}
}
