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
	public class FontePropriedadeIntelectualAppService : IFontePropriedadeIntelectualAppService
	{
		private readonly IServiceBase<FontePropriedadeIntelectual> _service;
		private readonly IMapper _mapper;

		public FontePropriedadeIntelectualAppService(IServiceBase<FontePropriedadeIntelectual> FontePropriedadeIntelectualService, IMapper mapper)
		{
			_service = FontePropriedadeIntelectualService;
			_mapper = mapper;

		}

		public FontePropriedadeIntelectualViewModel Add(FontePropriedadeIntelectualViewModel obj)
		{
			var modelObj = _mapper.Map<FontePropriedadeIntelectual>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<FontePropriedadeIntelectualViewModel>(modelObj);
		}


		public IList<FontePropriedadeIntelectualViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<FontePropriedadeIntelectual> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))
				   || (p.EdicaoDoLivro.ToLower().Contains(text.ToLower()))
				   || (p.Titulo.ToLower().Contains(text.ToLower()))
				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<FontePropriedadeIntelectualViewModel>>(modelObjs);

		}

		public IList<FontePropriedadeIntelectualViewModel> Find(Expression<Func<FontePropriedadeIntelectualViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<FontePropriedadeIntelectual, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<FontePropriedadeIntelectualViewModel>>(modelObjs);
		}

		public IList<FontePropriedadeIntelectualViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<FontePropriedadeIntelectual> modelObjs = null;

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
					   || (p.EdicaoDoLivro.ToLower().Contains(text.ToLower()))
					   || (p.Titulo.ToLower().Contains(text.ToLower()))
					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<FontePropriedadeIntelectualViewModel>>(modelObjs);
		}

		public IList<FontePropriedadeIntelectualViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<FontePropriedadeIntelectualViewModel>>(mdelObjs);
		}

		public FontePropriedadeIntelectualViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<FontePropriedadeIntelectualViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<FontePropriedadeIntelectualViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<FontePropriedadeIntelectual, bool>>>(predicate);

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

		public void Update(FontePropriedadeIntelectualViewModel obj)
		{
			var modelObj = _mapper.Map<FontePropriedadeIntelectual>(obj);

			_service.Update(modelObj);
		}

		void IAppServiceBase<FontePropriedadeIntelectualViewModel>.RemoveChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			var lista = FindChildrenOf(idPai, text, from, to);
			foreach (var i in lista)
			{
				_service.Remove(i.Id ?? Guid.Empty);
			}
		}
	}
}
