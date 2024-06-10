using webapi.barberdevs.Domains;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Interfaces
{
    public interface IBarbeiroRepository
    {
        //CRUD
        void Cadastrar(Usuario user);
        void Deletar(Guid id);
        List<Barbeiro> Listar();
        Barbeiro BuscarPorId(Guid id);
        Barbeiro Atualizar(Guid id, BarbeiroViewModel barbeiro);
    }
}
