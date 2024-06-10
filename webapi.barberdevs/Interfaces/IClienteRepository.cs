using webapi.barberdevs.Domains;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Interfaces
{
    public interface IClienteRepository
    {
        //CRUD
        void Cadastrar(Usuario user);
        void Deletar(Guid id);
        List<Cliente> Listar();
        Cliente BuscarPorId(Guid id);
        Cliente Atualizar(Guid id, ClienteViewModel cliente);
    }
}
