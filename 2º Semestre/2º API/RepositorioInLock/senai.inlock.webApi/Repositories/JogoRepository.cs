using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        public string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        //public string StringConexao = "Data Source = DESKTOP-1CNOHAQ\\SQLEXPRESS; Initial Catalog = inlock_games_tarde; Integrated Security = true";

        public void Cadastrar(JogoDomain novoJogo)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //declara a query
                string queryInsert = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES(@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con)) 
                {
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            //cria uma lista onde será guardado os filmes
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                /*
                IdUsuario INT PRIMARY KEY IDENTITY
               ,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(IdTipoUsuario)
               ,Email VARCHAR(100) NOT NULL UNIQUE
               ,Senha VARCHAR (100) NOT NULL
                */

                //Defini a query
                string querySelectAll = "SELECT Jogo.IdJogo ,Jogo.Nome AS NomeJogo, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Jogo.IdEstudio AS IdEstudio, Estudio.Nome as NomeEstudio FROM Jogo INNER JOIN Estudio ON Estudio.IdEstudio = Jogo.IdEstudio";

                con.Open();

                //Executa a query e armazena os dados no rdr
                SqlDataReader rdr;

                //Declara o sqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver resgistros à serem lidos no rdr o laço se repetirá
                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            //Atribui valor a propriedade Nome a uma variavel
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome =Convert.ToString(rdr["NomeJogo"]),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToString(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(rdr["Valor"])
                        };

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = Convert.ToString(rdr["NomeEstudio"]) 
                        };
                        jogo.estudioDomain = estudio;
                        ListaJogos.Add(jogo);
                    }
                }
                return ListaJogos;
            }
        }
    }
}
