using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Utils;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Signers;

namespace BarberDevs_API.Repositories
{
    public class BarbeiroRepository : IBarbeiroRepository
    {

        BarberDevsContext ctx = new BarberDevsContext();

        //Terminar essa função
        public List<Agendamento> BuscarPorData(DateTime DataAgendamento, Guid idBarbeiro)
        {
            throw new NotImplementedException();
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
