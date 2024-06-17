using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Utils;
using webapi.barberdevs.ViewModel;

namespace webapi.barberdevs.Repositories
{
    public class BarbeiroRepository : IBarbeiroRepository
    {

        private readonly BarberDevsContext _context;

        public BarbeiroRepository()
        {
           _context = new BarberDevsContext();
        }
        public Barbeiro Atualizar(Guid id, BarbeiroViewModel barbeiro)
        {
            try
            {
                Barbeiro barbeiroBuscado = _context.Barbeiros.Include(x => x.IdBarbeiroNavigation).FirstOrDefault(x => x.IdBarbeiro == id)!;

                if (barbeiroBuscado == null)
                {
                    return null!;
                }

                if (barbeiro.Descricao != null)
                {
                    barbeiroBuscado.Descricao = barbeiro.Descricao;
                }

                if (barbeiro.Cpf != null)
                {
                    barbeiroBuscado.IdBarbeiroNavigation.Cpf = barbeiro.Cpf;
                }

                if (barbeiro.Rg != null)
                {
                    barbeiroBuscado.IdBarbeiroNavigation.Rg = barbeiro.Rg;
                }

                if (barbeiro.Nome != null)
                {
                    barbeiroBuscado.IdBarbeiroNavigation.Nome = barbeiro.Nome;
                }

                if (barbeiro.Email != null)
                {
                    barbeiroBuscado.IdBarbeiroNavigation.Email = barbeiro.Email;
                }


                _context.Barbeiros.Update(barbeiroBuscado!);
                _context.SaveChanges();
                return barbeiroBuscado!;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Barbeiro BuscarPorId(Guid id)
        {
            try
            {
                return _context.Barbeiros
                   .Include(x => x.IdBarbeiroNavigation)
                   .Include(x => x.IdBarbeariaNavigation)
                   .FirstOrDefault(x => x.IdBarbeiro == id)!;
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
                user.Senha = Criptografia.GerarHash(user.Senha);
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
                Barbeiro barbeiroBuscado = _context.Barbeiros.Find(id)!;

                if (barbeiroBuscado != null)
                {
                    _context.Barbeiros.Remove(barbeiroBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Barbeiro> Listar()
        {
            try
            {
                return _context.Barbeiros.Include(x => x.IdBarbeiroNavigation).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
