using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Utils;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BarberDevsContext _context;

        public ClienteRepository()
        {
            _context = new BarberDevsContext();
        }

        public Cliente Atualizar(Guid id, ClienteViewModel cliente)
        {
            try
            {
                Cliente clienteBuscado = _context.Clientes.Include(x => x.IdClienteNavigation).FirstOrDefault(x => x.IdCliente == id)!;

                if (clienteBuscado == null)
                {
                    return null!;
                }

                if (cliente.Cpf != null)
                {
                    clienteBuscado.IdClienteNavigation.Cpf = cliente.Cpf;
                }

                if (cliente.Rg != null)
                {
                    clienteBuscado.IdClienteNavigation.Rg = cliente.Rg;
                }

                if (cliente.Nome != null)
                {
                    clienteBuscado.IdClienteNavigation.Nome = cliente.Nome;
                }

                if (cliente.Email != null)
                {
                    clienteBuscado.IdClienteNavigation.Email = cliente.Email;
                }


                _context.Clientes.Update(clienteBuscado!);
                _context.SaveChanges();
                return clienteBuscado!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente BuscarPorId(Guid id)
        {
            try
            {
                return _context.Clientes
                    .Include(x => x.IdClienteNavigation)
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
