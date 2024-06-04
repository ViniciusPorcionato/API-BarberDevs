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
            try
            {
                Agendamento agendamentoBuscado = ctx.Agendamento.FirstOrDefault(x => x.IdAgendamento == id)!;

                if (agendamentoBuscado != null)
                {
                    ctx.Agendamento.Remove(agendamentoBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> ListarPorBarbeiro(Guid idBarbeiro)
        {
            try
            {
                List<Agendamento> listaAgendamentos = ctx.Agendamento
                .Include(x => x.Cliente)
                .Include(x => x.Barbeiro)
                .Where(x => x.IdBarbeiro != null && x.IdBarbeiro == idBarbeiro)
                .ToList();

                return listaAgendamentos;
            } 
            catch (Exception)
            {

                throw;
            }
        }


        public List<Agendamento> ListarPorCliente(Guid idCliente)
        {
            try
            {
                List<Agendamento> listaAgendamentos = ctx.Agendamento
                    .Include(x => x.Cliente)
                    .Include (x => x.Barbeiro)
                    .Where(x => x.IdCliente != null && x.IdCliente == idCliente) .ToList();

                return listaAgendamentos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> ListarTodos()
        {
            return ctx.Agendamento.ToList();
        }
    }
}
