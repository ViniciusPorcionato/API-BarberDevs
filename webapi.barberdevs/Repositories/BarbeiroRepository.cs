using Microsoft.EntityFrameworkCore;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class BarbeiroRepository : IBarbeiroRepository
    {

        private readonly BarberDevsContext _context;

        public BarbeiroRepository()
        {
           _context = new BarberDevsContext();
        }
        public void Atualizar(Guid id, Barbeiro barbeiro)
        {
            Barbeiro barbeiroBuscado = _context.Barbeiros.Find(id)!;

            if (barbeiroBuscado != null)
            {
                barbeiroBuscado.Descricao = barbeiro.Descricao;
            }

            _context.Barbeiros.Update(barbeiroBuscado!);
            _context.SaveChanges();
        }

        public Barbeiro BuscarPorId(Guid id)
        {
            try
            {
                return _context.Barbeiros.Find(id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Barbeiro barbeiro)
        {
            try
            {
                _context.Barbeiros.Add(barbeiro);
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
                return _context.Barbeiros.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
