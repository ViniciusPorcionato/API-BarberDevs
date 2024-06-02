using BarberDevs_API.Domains;

namespace BarberDevs_API.Interfaces
{
    public interface IClienteRepository
    {
        public List<Cliente> ListarTodos();
        public Cliente BuscarPorId(Guid id);
        public void Cadastrar(Usuario cliente);
        public List<Agendamento> BuscarPorData(DateTime DataAgendamento, Guid idCliente);
    }
}
