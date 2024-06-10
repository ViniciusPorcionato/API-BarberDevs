using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Utils.Mail;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecupSenhaController : ControllerBase
    {
        private readonly BarberDevsContext _context;
        private readonly EmailSedingService _emailSedingService;

        public RecupSenhaController(BarberDevsContext context, EmailSedingService emailSedingService)
        {
            _context = context;
            _emailSedingService = emailSedingService;
        }

        [HttpPost("EnviarCodSenha")]
        public async Task<ActionResult> sendRecoveryCodePassword(string email)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

                if (usuario == null)
                {
                    return NotFound("Usuario não encontrado !");
                }

                Random random = new Random();

                int recoveryCode = random.Next(1000, 9999);

                usuario.CodRecupSenha = recoveryCode;

                await _context.SaveChangesAsync();

                await _emailSedingService.SendRocovery(usuario.Email!, recoveryCode);

                return Ok("Codigo enviado com sucesso !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost("ConfirmarCodigo")]
        public async Task<IActionResult> ConfirmSendCode(string email, int codigo)
        {
            try
            {
                var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null)
                {
                    return NotFound("Usuario não encontrado !");
                }

                if (user.CodRecupSenha != codigo)
                {
                    return Ok("Código Inválido");
                }

                user.CodRecupSenha = null;
                await _context.SaveChangesAsync();
                return Ok("Código de recuperação válido !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

    }
}
