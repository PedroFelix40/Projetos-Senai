using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>Todos os jogos cadastrados</returns>
        List<JogoDomain> ListarTodos();
    }
}
