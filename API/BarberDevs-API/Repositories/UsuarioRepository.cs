using BarberDevs_API.Contexts;
using BarberDevs_API.Domains;
using BarberDevs_API.Interfaces;
using BarberDevs_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace BarberDevs_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        BarberDevsContext ctx = new BarberDevsContext();
        public bool AlterarSenha(string email, string senhaNova)
        {
            try
            {
                var user = ctx.Usuario.FirstOrDefault(x => x.Email == email);

                if (user == null ) 
                {
                    return false;
                }

                user.Senha = Criptografia.GerarHash(senhaNova);

                ctx.Update(user);
                return true;
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
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Foto = novaUrlFoto;
                }

                ctx.SaveChanges();
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
                var user = ctx.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    Senha = u.Senha,
                    Nome = u.Nome

                }).FirstOrDefault(x => x.Email == email);

                if (user == null)
                {
                    return null!;
                }

                if (!Criptografia.ComparaHash(senha, user.Senha!))
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
                return ctx.Usuario.FirstOrDefault(x => x.IdUsuario == id)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
            ctx.Add(usuario);
            ctx.SaveChanges();
        }


    }
}
