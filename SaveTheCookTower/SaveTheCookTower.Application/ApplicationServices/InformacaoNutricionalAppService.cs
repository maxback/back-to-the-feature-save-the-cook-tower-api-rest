﻿using AutoMapper;
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
	public class InformacaoNutricionalAppService : IInformacaoNutricionalAppService
	{
		private readonly IServiceBase<InformacaoNutricional> _service;
		private readonly IMapper _mapper;

		public InformacaoNutricionalAppService(IServiceBase<InformacaoNutricional> InformacaoNutricionalService, IMapper mapper)
		{
			_service = InformacaoNutricionalService;
			_mapper = mapper;

		}

		public InformacaoNutricionalViewModel Add(InformacaoNutricionalViewModel obj)
		{
			var modelObj = _mapper.Map<InformacaoNutricional>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<InformacaoNutricionalViewModel>(modelObj);
		}

		public IList<InformacaoNutricionalViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<InformacaoNutricional> modelObjs = null;

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
			return _mapper.Map<List<InformacaoNutricionalViewModel>>(modelObjs);
		}

		public IList<InformacaoNutricionalViewModel> Find(Expression<Func<InformacaoNutricionalViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<InformacaoNutricional, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<InformacaoNutricionalViewModel>>(modelObjs);
		}

		public IList<InformacaoNutricionalViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<InformacaoNutricional> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.IngredienteId == idPai || 
				                               p.ReceitaId == idPai || p.UnidadeMedidaId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.IngredienteId == idPai ||
                        p.ReceitaId == idPai || p.UnidadeMedidaId == idPai) &&
				   (
				     (p.Nome.ToLower().Contains(text.ToLower()))
				     || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<InformacaoNutricionalViewModel>>(modelObjs);
		}

		public IList<InformacaoNutricionalViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<InformacaoNutricionalViewModel>>(mdelObjs);
		}

		public InformacaoNutricionalViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<InformacaoNutricionalViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<InformacaoNutricionalViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<InformacaoNutricional, bool>>>(predicate);

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

		public void Update(InformacaoNutricionalViewModel obj)
		{
			var modelObj = _mapper.Map<InformacaoNutricional>(obj);

			_service.Update(modelObj);
		}

		void IAppServiceBase<InformacaoNutricionalViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
