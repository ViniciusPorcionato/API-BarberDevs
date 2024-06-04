using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Repositories;
using BarberDevs_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BarberDevs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //[HttpPost]
        //public IActionResult Login(LoginViewModel usuario)
        //{
        //    Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

        //    if (usuarioBuscado == null)
        //    {
        //        return StatusCode(401, "Email ou senha inválidos");
        //    }

        //    var claims = new[]
        //        {
        //            new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
        //            new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
        //            new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario!.ToString()),
        //        };
        //}
    }
}
