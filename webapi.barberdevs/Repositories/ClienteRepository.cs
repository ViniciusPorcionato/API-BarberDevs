using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Utils;

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
                return _context.Clientes
                    //.Include(x => x.IdClienteNavigation)
                    .FirstOrDefault(x => x.IdCliente == id)!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario user)
        {
            try
            {
                user.Senha = Criptografia.GerarHash(user.Senha!);
                _context.Usuarios.Add(user);
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
