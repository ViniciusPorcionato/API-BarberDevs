using BarberDevs_API.Domains;

namespace BarberDevs_API.Interfaces
{
    public interface IAgendamentoRepository
    {
        public void Cadastrar(Agendamento agendamento);
        public Agendamento BuscarPorId(Guid id);
        public void Deletar(Guid id);
        public List<Agendamento> ListarTodos();
        public List<Agendamento> ListarPorBarbeiro();
        public Lis<Agendamento> ListarPorCliente();
    }
}
