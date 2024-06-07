using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BarberDevsContext _context;

        public ClienteRepository()
        {
            _context = new BarberDevsContext();
        }

        public void Atualizar(Guid id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(Guid id)
        {
            try
            {
                return _context.Clientes.Find(id)!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
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
               Cliente clienteBuscado = _context.Clientes.Find(id)!;

                if (clienteBuscado != null)
                {
                    _context.Clientes.Remove(clienteBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
               return _context.Clientes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
