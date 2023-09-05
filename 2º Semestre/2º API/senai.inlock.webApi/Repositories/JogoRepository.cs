using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";

        public void Cadastrar(JogoDomain novoJogo)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            //cria uma lista onde será guardado os filmes
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //continuar daqui...
            }
        }
    }
}
