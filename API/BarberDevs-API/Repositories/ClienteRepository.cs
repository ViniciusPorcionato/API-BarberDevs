using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Utils;
using BarberDevs_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BarberDevs_API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        BarberDevsContext ctx = new BarberDevsContext();

        public Cliente AtualizarPerfil(Guid id, ClienteViewModel cliente)
        {
            Cliente clienteBuscado = ctx.Cliente.Include(x => x.UsuarioCliente).FirstOrDefault(x => x.IdCliente == id)!;

            if (cliente.Rg != null)
            {
                clienteBuscado.Rg = cliente.Rg;
            }

            if (cliente.Cpf != null)
            {
                clienteBuscado.Cpf = cliente.Cpf;
            }

            if (cliente.Nome != null)
            {
                clienteBuscado.UsuarioCliente!.Nome = cliente.Nome;
            }

            if (cliente.Email != null)
            {
                clienteBuscado.UsuarioCliente!.Email = cliente.Email;
            }

            ctx.Cliente.Update(clienteBuscado!);
            ctx.SaveChanges();

            return (clienteBuscado!);
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

        public List<Agendamento> ListarAgendamentos(Guid idCliente)
        {
            try
            {
                return ctx.Agendamento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
