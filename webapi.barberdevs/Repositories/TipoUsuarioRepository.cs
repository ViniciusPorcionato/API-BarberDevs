using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;

namespace webapi.barberdevs.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly BarberDevsContext _context;

        public TipoUsuarioRepository()
        {
            _context = new BarberDevsContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuarios.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuario.NomeTipoUsuario;
                }

                _context.TipoUsuarios.Update(tipoUsuarioBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoUsuarios.Find(id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _context.TipoUsuarios.Add(tipoUsuario);
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
                TipoUsuario tipoUsuarioBuscado = _context.TipoUsuarios.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TipoUsuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
