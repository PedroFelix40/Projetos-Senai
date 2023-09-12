using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        ///     - windows: Intrated Security = True
        ///     - SqlServer: User id = sa; Pwd = Senai@134
        /// </summary>
        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = FilmesTarde; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara instruçao
                string queryUpdateIdBody = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string atualizarUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";


                con.Open();

                using (SqlCommand cmd = new SqlCommand(atualizarUrl, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        /// <summary>
        /// Buscar genero atraés do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objero buscado</returns>
        /*
        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain generoEncontrado = new GeneroDomain();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //Declara instrução a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = " +id;

                //Abre a conexão com o bd
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        generoEncontrado.IdGenero = Convert.ToInt32(rdr[0]);
                        generoEncontrado.Nome = rdr[1].ToString();
                    }
                    
                }
            }
            return generoEncontrado;
        }
        */



        //feito pelo professor
        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain generoEncontrado = new GeneroDomain();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                //Declara instrução a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        generoEncontrado.IdGenero = Convert.ToInt32(rdr["IdGenero"]);
                        generoEncontrado.Nome = rdr["Nome"].ToString();
                        return generoEncontrado;
                    }


                }

            }
            return null;
        }

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastrado</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declaramos a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";

                con.Open();

                //delcara o sqlcommand, que serva para executar a instrução 
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //executa a query
                    cmd.ExecuteNonQuery();
                }

            }

        }
        /// <inheritdoc/>




        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //1º
                //Declaramos a query que será executada
                //string queryDelete = "DELETE FROM Genero WHERE IdGenero = " + id;

                //Declaramos a query que será executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                //1º
                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados 
                //SqlDataReader rdr;

                using (SqlCommand cmd = new(queryDelete, con))
                {
                    //Abre conexao com o bd
                    con.Open();

                    //1º jeito
                    //rdr = cmd.ExecuteReader();

                    cmd.Parameters.AddWithValue("IdGenero", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos, onde será armazenados os generos
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //ABre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados 
                SqlDataReader rdr;

                //Declara o sqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver resgistros à serem lidos no rdr o laço se repetirá
                    while (rdr.Read())
                    {
                        //Instancia um objeto do tipo GeneroDOmain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero à uma variavel, sendo ela o primeiro valor de uma tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propiedade nome o valor da coluna nome
                            Nome = rdr[1].ToString()
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }
            }
            //Retorna a lista de generos 
            return ListaGeneros;
        }

    }
}
