using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly BarberDevsContext _context;

        public AgendamentoRepository()
        {
            _context = new BarberDevsContext();
        }


        public Agendamento BuscarPorId(Guid id)
        {
            try
            {
               return _context.Agendamentos.Find(id)!;
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
                _context.Agendamentos.Add(agendamento);
                _context.SaveChanges();
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
                Agendamento agendamento = _context.Agendamentos.Find(id)!;

                if (agendamento != null) 
                { 
                    _context.Agendamentos.Remove(agendamento);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> ListarPorBarbeiro(Guid IdBarbeiro)
        {
            try
            {
                return _context.Agendamentos
                    .Include(x => x.IdClienteNavigation!.IdClienteNavigation)
                    .Include(x => x.IdBarbeiroNavigation!.IdBarbeiroNavigation)
                    .Select(b => new Agendamento
                {
                    DataAgendamento = b.DataAgendamento,
                    IdBarbeiro = b.IdBarbeiro,
                    IdCliente = b.IdCliente,
                    IdAgendamento = b.IdAgendamento,
                    IdBarbeiroNavigation = b.IdBarbeiroNavigation,
                    IdClienteNavigation = b.IdClienteNavigation,
                }).Where(b => b.IdBarbeiro == IdBarbeiro).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> ListarPorCliente(Guid IdCliente)
        {
            try
            {
                return _context.Agendamentos
                    .Include(x => x.IdClienteNavigation!.IdClienteNavigation)
                    .Include(x => x.IdBarbeiroNavigation!.IdBarbeiroNavigation)
                    .Select(c => new Agendamento
                {
                    DataAgendamento = c.DataAgendamento,
                    IdBarbeiro = c.IdBarbeiro,
                    IdCliente = c.IdCliente,
                    IdAgendamento = c.IdAgendamento,
                    IdBarbeiroNavigation = c.IdBarbeiroNavigation,
                    IdClienteNavigation = c.IdClienteNavigation,

                }).Where(c => c.IdCliente == IdCliente).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Agendamento> ListarTodos()
        {
            try
            {
                return _context.Agendamentos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    } 
 }

