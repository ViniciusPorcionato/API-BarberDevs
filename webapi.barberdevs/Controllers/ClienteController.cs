using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Repositories;
using webapi.barberdevs.Utils.BlobStorage;
using webapi.barberdevs.Utils.Mail;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }


        [HttpGet("BuscarTodos")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clienteRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("BuscarPorId")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_clienteRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarCliente")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return Ok("Cliente removido!!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CadastrarCliente")]
        public async Task<IActionResult> Post([FromForm] ClienteViewModel clienteModel)
        {
            try
            {
                Usuario user = new Usuario();
                user.Nome = clienteModel.Nome!;
                user.Email = clienteModel.Email!;
                user.Cpf = clienteModel.Cpf;
                user.Rg = clienteModel.Rg;
                user.IdTipoUsuario = clienteModel.IdTipoUsuario;

                var containerName = "containerbarberdevs";

                var connectionStrings = "DefaultEndpointsProtocol=https;AccountName=barberdevsaccountstorage;AccountKey=CptEN0isYWgyXPX2JKdkPqCE/+dSRanxbWilfdFetkVuSH6kJtjj2aEtk3PCEYG9zj/U4lyKOSFf+ASt2gAjRA==;EndpointSuffix=core.windows.net";

                user.Foto = await AzureBlobStorageHelper.UploadImageBlobAsync(clienteModel.Arquivo!, connectionStrings, containerName);

                user.Senha = clienteModel.Senha!;

                user.Cliente = new Cliente();

                _clienteRepository.Cadastrar(user);
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarCliente")]
        public IActionResult Put(Guid id, ClienteViewModel cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok("Barbeiro atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
