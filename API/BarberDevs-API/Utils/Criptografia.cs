namespace BarberDevs_API.Utils
{
    public class Criptografia
    {
        /// <summary>
        /// Gera uma HASH a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a HASH</param>
        /// <returns>Senha criptografada com a HASH</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }


        /// <summary>
        /// Verifica se a HASH da senha informada é igual a HASH salva no BD
        /// </summary>
        /// <param name="senhaFormulario">Senha passada no formulario de login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True ou False</returns>
        public static bool ComparaHash(string senhaFormulario, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaFormulario, senhaBanco);
        }
    }
}
