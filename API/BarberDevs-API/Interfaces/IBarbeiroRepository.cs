using BarberDevs_API.Domains;

namespace BarberDevs_API.Interfaces
{
    public interface IBarbeiroRepository
    {
        public List<Barbeiro> ListarTodos();
        public Barbeiro BuscarPorId(Guid id);
        public void Cadastrar(Usuario barbeiro);
        public List<Agendamento> BuscarPorData(DateTime DataAgendamento, Guid idBarbeiro);
    }
}
