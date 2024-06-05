using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Repositories;
using BarberDevs_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BarberDevs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository agendamentoRepository;

        public AgendamentoController()
        {
            agendamentoRepository = new AgendamentoRepository();
        }

        [HttpGet("AgendamentoCliente")]
        public IActionResult GetByIdCliente()
        {
            try
            {
                Guid idUsuario = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Agendamento> agendamentos = agendamentoRepository.ListarPorCliente(idUsuario);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet("AgendamentoBarbeiro")]
        public IActionResult GetByIdBarbeiro()
        {
            try
            {
                Guid idUsuario = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Agendamento> agendamentos = agendamentoRepository.ListarPorBarbeiro(idUsuario);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Agendamento agendamentoBuscado = agendamentoRepository.BuscarPorId(id);
                return Ok(agendamentoBuscado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        //[HttpPost("CadastrarAgendamento")]
        //public IActionResult Post(AgendamentoViewModel agendamentoViewModel)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //        throw;
        //    }

        //}
    }
}
