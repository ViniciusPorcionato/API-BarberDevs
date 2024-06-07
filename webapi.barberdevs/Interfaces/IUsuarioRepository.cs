using webapi.barberdevs.Domains;

namespace webapi.barberdevs.Interfaces
{
    public interface IUsuarioRepository
    {
        void Atualizar(Guid id, Usuario usuario);
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

        bool AlterarSenha(string email, string senhaNova);

        public void AtualizarFoto(Guid id, string novaUrlFoto);
    }
}
