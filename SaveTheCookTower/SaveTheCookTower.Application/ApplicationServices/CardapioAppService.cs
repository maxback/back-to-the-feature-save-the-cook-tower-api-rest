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
	public class CardapioAppService : ICardapioAppService
	{
		private readonly IServiceBase<Cardapio> _service;
		private readonly IMapper _mapper;

		public CardapioAppService(IServiceBase<Cardapio> avaliacaoDoUsuarioService, IMapper mapper)
		{
			_service = avaliacaoDoUsuarioService;
			_mapper = mapper;

		}

		public CardapioViewModel Add(CardapioViewModel obj)
		{
			var modelObj = _mapper.Map<Cardapio>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<CardapioViewModel>(modelObj);
		}

		public IList<CardapioViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<Cardapio> modelObjs = null;

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
			return _mapper.Map<List<CardapioViewModel>>(modelObjs);
		}

		public IList<CardapioViewModel> Find(Expression<Func<CardapioViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<Cardapio, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<CardapioViewModel>>(modelObjs);
		}

		public IList<CardapioViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<Cardapio> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.CategoriaId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.CategoriaId == idPai) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))

					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<CardapioViewModel>>(modelObjs);
		}

		public IList<CardapioViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<CardapioViewModel>>(mdelObjs);
		}

		public CardapioViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<CardapioViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<CardapioViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<Cardapio, bool>>>(predicate);

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

		public void Update(CardapioViewModel obj)
		{
			var modelObj = _mapper.Map<Cardapio>(obj);

			_service.Update(modelObj);
		}


		void IAppServiceBase<CardapioViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
