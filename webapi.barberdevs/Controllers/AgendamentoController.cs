using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Repositories;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository _agendamentoRepository;

        public AgendamentoController()
        {
            _agendamentoRepository = new AgendamentoRepository();
        }

        [Authorize]
        [HttpGet("AgendamentosCliente")]
        public IActionResult GetByIdCliente()
        {
            try
            {
                Guid idUsuario = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Agendamento> agendamentos = _agendamentoRepository.ListarPorCliente(idUsuario);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [Authorize(Roles = "Barbeiro")]
        [HttpGet("AgendamentosBarbeiro")]
        public IActionResult GetByIdBarbeiro()
        {
            try
            {
                Guid idUsuario = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Agendamento> agendamentos = _agendamentoRepository.ListarPorBarbeiro(idUsuario);
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("CadastrarAgendamento")]
        public IActionResult Post(AgendamentoViewModel agendamentoViewModel)
        {
            try
            {
                Agendamento agendamento = new Agendamento();
                agendamento.DataAgendamento = agendamentoViewModel.DataAgendamento;
                agendamento.IdBarbeiro = agendamentoViewModel.IdBarbeiro;
                agendamento.IdCliente = agendamentoViewModel.IdCliente;

                _agendamentoRepository.Cadastrar(agendamento);

                return StatusCode(201, agendamento);
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
                Agendamento agendamentoBuscado = _agendamentoRepository.BuscarPorId(id);

                return Ok(agendamentoBuscado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarAgendamento")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _agendamentoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
