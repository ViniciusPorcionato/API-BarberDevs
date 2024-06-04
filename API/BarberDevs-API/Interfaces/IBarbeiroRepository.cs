using BarberDevs_API.Domains;
using BarberDevs_API.ViewModels;

namespace BarberDevs_API.Interfaces
{
    public interface IBarbeiroRepository
    {
        public List<Barbeiro> ListarTodos();
        public Barbeiro BuscarPorId(Guid id);
        public void Cadastrar(Usuario barbeiro);

        public Barbeiro AtualizarPerfil(Guid id, BaebeiroViewModel barbeiro);
        public List<Agendamento> ListarAgendamentos(Guid idBarbeiro);
    }
}
