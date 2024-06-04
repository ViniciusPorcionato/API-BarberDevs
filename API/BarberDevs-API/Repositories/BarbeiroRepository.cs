using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Utils;
using BarberDevs_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Signers;

namespace BarberDevs_API.Repositories
{
    public class BarbeiroRepository : IBarbeiroRepository
    {

        BarberDevsContext ctx = new BarberDevsContext();

        public Barbeiro AtualizarPerfil(Guid id, BarbeiroViewModel barbeiro)
        {
            Barbeiro barbeiroBuscado = ctx.Barbeiro.Include(x => x.Barbearia).Include(x => x.UsuarioBarbeiro).FirstOrDefault(x => x.IdBarbeiro == id)!;

            if (barbeiro.Rg != null)
            {
                barbeiroBuscado!.Rg = barbeiro.Rg;
            }

            if (barbeiro.Cpf != null)
            {
                barbeiroBuscado.Cpf = barbeiro.Cpf;
            }

            if (barbeiro.Descricao != null)
            {
                barbeiroBuscado.Descricao = barbeiro.Descricao;
            }

            if (barbeiro.Nome != null)
            {
                barbeiroBuscado.UsuarioBarbeiro!.Nome = barbeiro.Nome;
            }

            if (barbeiro.Email != null)
            {
                barbeiroBuscado.UsuarioBarbeiro!.Email = barbeiro.Email;
            }

            ctx.Barbeiro.Update(barbeiroBuscado!);
            ctx.SaveChanges();

            return barbeiroBuscado!;

        }


        public Barbeiro BuscarPorId(Guid id)
        {
            try
            {
                return ctx.Barbeiro
                .Include(x => x.UsuarioBarbeiro)
                .Include(x => x.Barbearia)
                .FirstOrDefault(x => x.IdBarbeiro == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario barbeiro)
        {
            barbeiro.Senha = Criptografia.GerarHash(barbeiro.Senha!);
            ctx.Usuario.Add(barbeiro);
            ctx.SaveChanges();
        }

        public List<Agendamento> ListarAgendamentos(Guid idBarbeiro)
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

        public List<Barbeiro> ListarTodos()
        {
            try
            {
                return ctx.Barbeiro.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
