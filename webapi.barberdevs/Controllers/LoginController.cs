using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Repositories;
using webapi.barberdevs.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.barberdevs.Controllers
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

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario!.ToString()),
                    new Claim("role", usuarioBuscado.IdTipoUsuarioNavigation!.NomeTipoUsuario!)

                };

                //configurar a chave de segurança
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));

                //credenciais
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //configurar token
                var meuToken = new JwtSecurityToken(
                        issuer: "",
                        audience: "",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
                throw;
            }
        }
    }
}
