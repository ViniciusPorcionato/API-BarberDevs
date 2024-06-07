using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IBarbeiroRepository
    {
        //CRUD
        void Cadastrar(Barbeiro barbeiro);
        void Deletar(Guid id);
        List<Barbeiro> Listar();
        Barbeiro BuscarPorId(Guid id);
        void Atualizar(Guid id, Barbeiro barbeiro);
    }
}
