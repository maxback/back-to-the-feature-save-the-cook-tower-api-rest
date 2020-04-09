using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SaveTheCookTower.Application.Interfaces;
using SaveTheCookTower.Application.ViewModels;
using SaveTheCookTower.Application.ViewModels.Autenticacao;
using SaveTheCookTower.CrossCutting.Helpers;
using SaveTheCookTower.CrossCutting.Utils;

namespace SaveTheCookTower.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        //para injeção do app service
        private readonly IUsuarioAppService _usuarioAppService;
        //para injeção da configuração de SecretKeyJWT
        private readonly AppSettings _appSettings;

        public AutenticacaoController(IUsuarioAppService usuarioAppService, IOptions<AppSettings> appSettings)
        {
            _usuarioAppService = usuarioAppService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Post(LoginViewModel loginViewModel)
        {
            UsuarioViewModel usuarioViewModel;
            try
            {
                var result = _usuarioAppService.Login(loginViewModel.Login, loginViewModel.Password, out usuarioViewModel);

                //se usuário não encontrado sai
                if (!result)
                { 
                    if (loginViewModel.Login == "string" && loginViewModel.Password == "string")
                        return BadRequest("Você deve estar tentando isto da página da documentação. Por favor altere o JSON no campo \"Request body\" e chame o botão execute novamente.");
                    return BadRequest("Usuário ou senha não conferem.");
                }

                string token = GetHashJWT(usuarioViewModel);

                return Ok(new { access_token = token, usuario = usuarioViewModel});
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = $"Erro inesperado ao realizar login {e.Message}."}); 
            }
        }

        private string GetHashJWT(UsuarioViewModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKeyJWT);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}