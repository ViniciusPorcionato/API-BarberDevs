using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberDevs_API.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        BarberDevsContext ctx = new BarberDevsContext();
        public Agendamento BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Agendamento             
                .Include(x => x.Cliente)
                .Include(x => x.Barbeiro)
                .FirstOrDefault(x => x.IdAgendamento == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Agendamento agendamento)
        {
            try
            {
                ctx.Agendamento.Add(agendamento);
                ctx.SaveChanges();  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ListarPorBarbeiro()
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ListarPorCliente()
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
