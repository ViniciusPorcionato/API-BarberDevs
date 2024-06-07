using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        //CRUD
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid id);
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
