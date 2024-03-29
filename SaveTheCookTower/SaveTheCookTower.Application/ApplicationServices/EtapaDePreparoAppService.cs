﻿using AutoMapper;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.Interfaces.Base;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace SaveTheCookTower.Application.ApplicationServices
{
	public class EtapaDePreparoAppService : IEtapaDePreparoAppService
	{
		private readonly IServiceBase<EtapaDePreparo> _service;
		private readonly IMapper _mapper;

		public EtapaDePreparoAppService(IServiceBase<EtapaDePreparo> EtapaDePreparoService, IMapper mapper)
		{
			_service = EtapaDePreparoService;
			_mapper = mapper;

		}

		public EtapaDePreparoViewModel Add(EtapaDePreparoViewModel obj)
		{
			var modelObj = _mapper.Map<EtapaDePreparo>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<EtapaDePreparoViewModel>(modelObj);
		}


		public IList<EtapaDePreparoViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<EtapaDePreparo> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else if (text.ToLower().Contains("receitaid="))
			{
				var receitaId = text.Substring(10);

				modelObjs = _service.Find(p => p.ReceitaId.ToString() == receitaId, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))
				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<EtapaDePreparoViewModel>>(modelObjs);
		}

		public IList<EtapaDePreparoViewModel> Find(Expression<Func<EtapaDePreparoViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<EtapaDePreparo, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<EtapaDePreparoViewModel>>(modelObjs);
		}

		public IList<EtapaDePreparoViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<EtapaDePreparo> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.ReceitaId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.ReceitaId == idPai) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))
					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<EtapaDePreparoViewModel>>(modelObjs);
		}

		public IList<EtapaDePreparoViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<EtapaDePreparoViewModel>>(mdelObjs);
		}

		public EtapaDePreparoViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<EtapaDePreparoViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<EtapaDePreparoViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<EtapaDePreparo, bool>>>(predicate);

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

		public void Update(EtapaDePreparoViewModel obj)
		{
			var modelObj = _mapper.Map<EtapaDePreparo>(obj);

			_service.Update(modelObj);
		}


		void IAppServiceBase<EtapaDePreparoViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
