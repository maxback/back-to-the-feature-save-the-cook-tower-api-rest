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
	public class CategoriaAppService : ICategoriaAppService
	{
		private readonly IServiceBase<Categoria> _service;
		private readonly IMapper _mapper;

		public CategoriaAppService(IServiceBase<Categoria> avaliacaoDoUsuarioService, IMapper mapper)
		{
			_service = avaliacaoDoUsuarioService;
			_mapper = mapper;

		}

		public CategoriaViewModel Add(CategoriaViewModel obj)
		{
			var modelObj = _mapper.Map<Categoria>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<CategoriaViewModel>(modelObj);
		}

		public IList<CategoriaViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<Categoria> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))

				   || ((p.CategoriaPaiId?? Guid.Empty).ToString().ToLower().Contains(text.ToLower()))
				   || ( p.CategoriaPai == null ? false : p.CategoriaPai.Nome.ToLower().Contains(text.ToLower()) )

				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<CategoriaViewModel>>(modelObjs);
		}

		public IList<CategoriaViewModel> Find(Expression<Func<CategoriaViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<Categoria, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<CategoriaViewModel>>(modelObjs);
		}

		public IList<CategoriaViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<Categoria> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.CategoriaPaiId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.CategoriaPaiId == idPai) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))

					   || ((p.CategoriaPaiId ?? Guid.Empty).ToString().ToLower().Contains(text.ToLower()))
					   || (p.CategoriaPai == null ? false : p.CategoriaPai.Nome.ToLower().Contains(text.ToLower()))

					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<CategoriaViewModel>>(modelObjs);
		}

		public IList<CategoriaViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<CategoriaViewModel>>(mdelObjs);
		}

		public CategoriaViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<CategoriaViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<CategoriaViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<Categoria, bool>>>(predicate);

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

		public void Update(CategoriaViewModel obj)
		{
			var modelObj = _mapper.Map<Categoria>(obj);

			_service.Update(modelObj);
		}

		void IAppServiceBase<CategoriaViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
