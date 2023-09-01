using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método que busca um usuário por email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Objeto que foi buscado</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
