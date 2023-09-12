using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //TipoDeRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Este parametro é o objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os gêneros cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um obj atraves do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Atualizar um genero existente, passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto genero com novas informacões</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um genero existente passando o id pela url da requisicao
        /// </summary>
        /// <param name="id">id do obj a ser att</param>
        /// <param name="genero">obj com as novas infos</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deletar um genero existente
        /// </summary>
        /// <param name="id">id do obj a ser deletado</param>
        void Deletar(int id);
    }
}
