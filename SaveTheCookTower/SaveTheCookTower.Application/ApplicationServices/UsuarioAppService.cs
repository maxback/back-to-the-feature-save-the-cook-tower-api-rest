using AutoMapper;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.CrossCutting.Utils;
using SaveTheCookTower.Domain.Interfaces.Base;
using SaveTheCookTower.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public IList<UsuarioViewModel> Find(string text, int? fromIndex = null, int? toIndex = null)
		{
			IList<Usuario> modelObjs = null;

			if (string.IsNullOrEmpty(text))
			{
				modelObjs = _service.Find(p => true, fromIndex, toIndex);
			}
			else
			{
				modelObjs = _service.Find(
				   p => (p.Nome.ToLower().Contains(text.ToLower()))
				   || (p.Login.ToLower().Contains(text.ToLower()))
				   || (p.Token.ToLower().Contains(text.ToLower()))
				   || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   , fromIndex, toIndex);
			}
			return _mapper.Map<List<UsuarioViewModel>>(modelObjs);
		}


		public IList<UsuarioViewModel> Find(Expression<Func<UsuarioViewModel, bool>> predicate, int? fromIndex, int? toIndex)
		{
		//erro ao resolver o mapp do expression
		//ver como mapear
		https://stackoverflow.com/questions/53940242/automapper-expression-mapping-issue
			var newPredicate = _mapper.Map<Expression<Func<Usuario, bool>>>(predicate);
			var modelObjs = _service.Find(newPredicate, fromIndex, toIndex);

			return _mapper.Map<List<UsuarioViewModel>>(modelObjs);
		}

		/// <summary>
		/// Metofdo que testa se os dados de login correspondem e retorna um objeto do usuário
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <param name="usuario"> Usuário correspondente ao login (ou nulo)</param>
		/// <returns>True se aceitou o login</returns>
		public bool Login(string login, string password, out UsuarioViewModel usuario)
		{
			Usuario usuarioModel;
			usuarioModel = _service.Find(p => (p.Email == login || p.Login == login)
						                 && p.Password == password.ToHashMD5()
										 && !p.ForaDeUso,
						                  0, 0).FirstOrDefault();

			usuario = _mapper.Map<UsuarioViewModel>(usuarioModel);

			return (usuario != null);

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

		public IList<UsuarioViewModel> FindChildrenOf(Guid idPai, string text, int? from, int? to)
		{
			IList<Usuario> modelObjs = null;

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
				     || (p.Login.ToLower().Contains(text.ToLower()))
				     || (p.Token.ToLower().Contains(text.ToLower()))
				     || (p.Sinonimos.ToLower().Contains(text.ToLower()))
				   )
				   , from, to);
			}
			return _mapper.Map<List<UsuarioViewModel>>(modelObjs);
		}
	}
}
