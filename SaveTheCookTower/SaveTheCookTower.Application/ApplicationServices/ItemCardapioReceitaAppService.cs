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
	public class ItemCardapioReceitaAppService : IItemCardapioReceitaAppService
	{
		private readonly IServiceBase<ItemCardapioReceita> _service;
		private readonly IMapper _mapper;

		public ItemCardapioReceitaAppService(IServiceBase<ItemCardapioReceita> avaliacaoDoUsuarioService, IMapper mapper)
		{
			_service = avaliacaoDoUsuarioService;
			_mapper = mapper;

		}

		public ItemCardapioReceitaViewModel Add(ItemCardapioReceitaViewModel obj)
		{
			var modelObj = _mapper.Map<ItemCardapioReceita>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<ItemCardapioReceitaViewModel>(modelObj);
		}

		public IList<ItemCardapioReceitaViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<ItemCardapioReceita> modelObjs = null;

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
			return _mapper.Map<List<ItemCardapioReceitaViewModel>>(modelObjs);
		}

		public IList<ItemCardapioReceitaViewModel> Find(Expression<Func<ItemCardapioReceitaViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemCardapioReceita, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<ItemCardapioReceitaViewModel>>(modelObjs);
		}

		public IList<ItemCardapioReceitaViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<ItemCardapioReceita> modelObjs = null;

			if (text == "*") //indica relacao de pais diversas
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.ItemCardapioId == idPai ||
				(p.ItemCardapio != null && p.ItemCardapio.CardapioId == idPai), from, to);
			}
			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.ItemCardapioId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.ItemCardapioId == idPai ||
						 (p.ItemCardapio != null && p.ItemCardapio.CardapioId == idPai)) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))

					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<ItemCardapioReceitaViewModel>>(modelObjs);
		}

		public IList<ItemCardapioReceitaViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<ItemCardapioReceitaViewModel>>(mdelObjs);
		}

		public ItemCardapioReceitaViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<ItemCardapioReceitaViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<ItemCardapioReceitaViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemCardapioReceita, bool>>>(predicate);

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

		public void Update(ItemCardapioReceitaViewModel obj)
		{
			var modelObj = _mapper.Map<ItemCardapioReceita>(obj);

			_service.Update(modelObj);
		}
	}
}
