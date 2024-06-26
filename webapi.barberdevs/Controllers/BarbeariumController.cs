﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Repositories;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeariumController : ControllerBase
    {
        private IBarbeariumRepository _barbeariumRepository { get; set; }

        public BarbeariumController()
        {
            _barbeariumRepository =  new BarbeariumRepository();
        }

        [HttpGet("ListarBarbearia")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_barbeariumRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }


        [HttpGet("BuscarPorId{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_barbeariumRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Post(Barbearium barbearium)
        {
            try
            {
                _barbeariumRepository.Cadastrar(barbearium);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("DeletarBarbearia{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _barbeariumRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("AtualizarBarbearia{id}")]
        public IActionResult Put(Guid id, Barbearium barbearium)
        {
            try
            {
                _barbeariumRepository.Atualizar(id, barbearium);

                return NoContent() ;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

    }
}
