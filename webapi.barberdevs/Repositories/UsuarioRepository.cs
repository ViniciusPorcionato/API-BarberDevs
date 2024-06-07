using System.Reflection.Metadata.Ecma335;
using webapi.barberdevs.Contexts;
using webapi.barberdevs.Domains;
using webapi.barberdevs.Interfaces;
using webapi.barberdevs.Utils;

namespace webapi.barberdevs.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BarberDevsContext _context;

        public UsuarioRepository()
        {
                _context = new BarberDevsContext();
        }
        public bool AlterarSenha(string email, string senhaNova)
        {
            try
            {
                var user = _context.Usuarios.FirstOrDefault(x => x.Email == email);

                if (user == null)
                {
                    return false;
                }

                user.Senha = Criptografia.GerarHash(senhaNova);
                _context.Usuarios.Update(user);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.Find(id)!;
                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Nome = usuario.Nome;
                    usuarioBuscado.Email = usuario.Email;
                    usuarioBuscado.Rg = usuario.Rg;
                    usuarioBuscado.Cpf = usuario.Cpf;
                }

                _context.Usuarios.Update(usuarioBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarFoto(Guid id, string novaUrlFoto)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Foto = novaUrlFoto;  
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                var user = _context.Usuarios.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    Foto = u.Foto,
                    Rg = u.Rg,
                    Cpf = u.Cpf,
                    IdTipoUsuarioNavigation = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuarioNavigation!.IdTipoUsuario,
                        NomeTipoUsuario = u.IdTipoUsuarioNavigation!.NomeTipoUsuario
                    }
                }).FirstOrDefault(x => x.Email == email);

                if (user != null)
                {
                    return null!;
                }

                if (!Criptografia.CompararHash(senha, user.Senha!))
                {
                    return null!;
                }

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
                _context.Usuarios.Add(usuario);
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
                Usuario usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _context.Usuarios.Remove(usuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
