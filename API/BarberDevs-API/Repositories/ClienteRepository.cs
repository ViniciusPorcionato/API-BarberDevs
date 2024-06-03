using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace BarberDevs_API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        BarberDevsContext ctx = new BarberDevsContext();
        public List<Agendamento> BuscarPorData(DateTime DataAgendamento, Guid idCliente)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Cliente
                    .Include(x => x.UsuarioCliente)
                    .FirstOrDefault(x => x.IdCliente == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario cliente)
        {
            try
            {
                cliente.Senha = Criptografia.GerarHash(cliente.Senha!);
                ctx.Usuario.Add(cliente);
                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> ListarTodos()
        {
            try
            {
                return ctx.Cliente.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
