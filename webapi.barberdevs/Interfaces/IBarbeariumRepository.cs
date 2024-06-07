using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IBarbeariumRepository
    {
        //CRUD
        public void Cadastrar(Barbearium barbearium);
        public void Deletar(Guid id);
        List<Barbearium> Listar();
        Barbearium BuscarPorId(Guid id);
        public void Atualizar(Guid id, Barbearium barbearium);
    }
}
