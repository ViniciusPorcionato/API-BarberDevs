using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IClienteRepository
    {
        //CRUD
        void Cadastrar(Cliente cliente);
        void Deletar(Guid id);
        List<Cliente> Listar();
        Cliente BuscarPorId(Guid id);
        void Atualizar(Guid id, Cliente cliente);
    }
}
