using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Repositories;
using webapi.barberdevs.Utils.BlobStorage;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbeiroController : ControllerBase
    {
        private IBarbeiroRepository _barbeiroRepository;

        public BarbeiroController()
        {
            _barbeiroRepository = new BarbeiroRepository();
        }

        [HttpGet("BuscarTodos")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_barbeiroRepository.Listar());
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
                return Ok(_barbeiroRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeletarBarbeiro")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _barbeiroRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CadastrarBarbeiro")]
        public async Task<IActionResult> Post([FromForm] BarbeiroViewModel barbeiroModel)
        {
            try
            {
                Usuario user = new Usuario();
                user.Nome = barbeiroModel.Nome!;
                user.Email = barbeiroModel.Email!;
                user.IdTipoUsuario = barbeiroModel.IdTipoUsuario;
                user.Cpf = barbeiroModel.Cpf;
                user.Rg = barbeiroModel.Rg;

                var containerName = "containerbarberdevs";

                var connectionStrings = "DefaultEndpointsProtocol=https;AccountName=barberdevsaccountstorage;AccountKey=CptEN0isYWgyXPX2JKdkPqCE/+dSRanxbWilfdFetkVuSH6kJtjj2aEtk3PCEYG9zj/U4lyKOSFf+ASt2gAjRA==;EndpointSuffix=core.windows.net";

                user.Foto = await AzureBlobStorageHelper.UploadImageBlobAsync(barbeiroModel.Arquivo!, connectionStrings, containerName);

                user.Senha = barbeiroModel.Senha!;

                user.Barbeiro = new Barbeiro();
                user.Barbeiro.Descricao = barbeiroModel.Descricao;

                _barbeiroRepository.Cadastrar(user);
                return Ok("Barbeiro cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarBarbeiro")]
        public IActionResult Put(Guid id, BarbeiroViewModel barbeiro)
        {
            try
            {
                _barbeiroRepository.Atualizar(id, barbeiro);
                return Ok("Barbeiro atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

