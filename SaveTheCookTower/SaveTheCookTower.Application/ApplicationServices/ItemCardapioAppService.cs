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
	public class ItemCardapioAppService : IItemCardapioAppService
	{
		private readonly IServiceBase<ItemCardapio> _service;
		private readonly IMapper _mapper;

		public ItemCardapioAppService(IServiceBase<ItemCardapio> avaliacaoDoUsuarioService, IMapper mapper)
		{
			_service = avaliacaoDoUsuarioService;
			_mapper = mapper;

		}

		public ItemCardapioViewModel Add(ItemCardapioViewModel obj)
		{
			var modelObj = _mapper.Map<ItemCardapio>(obj);
			modelObj = _service.Add(modelObj);

			return _mapper.Map<ItemCardapioViewModel>(modelObj);
		}

		public IList<ItemCardapioViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<ItemCardapio> modelObjs = null;

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
			return _mapper.Map<List<ItemCardapioViewModel>>(modelObjs);
		}

		public IList<ItemCardapioViewModel> Find(Expression<Func<ItemCardapioViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemCardapio, bool>>>(predicate);

			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<ItemCardapioViewModel>>(modelObjs);
		}

		public IList<ItemCardapioViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<ItemCardapio> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => p.CriadoPorId == idPai || p.CardapioId == idPai, from, to);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.CriadoPorId == idPai || p.CardapioId == idPai) &&
				   (
					   (p.Nome.ToLower().Contains(text.ToLower()))

					   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<ItemCardapioViewModel>>(modelObjs);
		}

		public IList<ItemCardapioViewModel> GetAll()
		{
			var mdelObjs = _service.GetAll();

			return _mapper.Map<List<ItemCardapioViewModel>>(mdelObjs);
		}

		public ItemCardapioViewModel GetById(Guid id)
		{
			var madelObj = _service.GetById(id);

			return _mapper.Map<ItemCardapioViewModel>(madelObj);
		}

		public int GetCount(Expression<Func<ItemCardapioViewModel, bool>> predicate)
		{
			var newPredicate = _mapper.Map<Expression<Func<ItemCardapio, bool>>>(predicate);

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

		public void Update(ItemCardapioViewModel obj)
		{
			var modelObj = _mapper.Map<ItemCardapio>(obj);

			_service.Update(modelObj);
		}
	}
}
