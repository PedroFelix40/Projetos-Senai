using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Lista todos os estudios e seus respectivos jogos
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> Listar();
    }
}
