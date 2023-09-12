using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = FilmesTarde; User Id = sa; Pwd = Senai@134";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara instruçao
                string queryUpdateIdBody = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFIlme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string atualizarUrl = "UPDATE Filme SET TItulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";


                con.Open();

                using (SqlCommand cmd = new SqlCommand(atualizarUrl, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado= new FilmeDomain();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //ação que sera executada no bd
                string querySelectById = "SELECT * FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("IdFilme", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        filmeBuscado.IdFilme = Convert.ToInt32(rdr["IdFilme"]);
                        
                        filmeBuscado.IdGenero = Convert.ToInt32(rdr["IdGenero"]);

                        filmeBuscado.Titulo = rdr["Titulo"].ToString();

                        return filmeBuscado;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes que serao cadastrado</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declaramos a query que será executada
                string queryInsert = "INSERT INTO Filme(IdGenero, Titulo) VALUES(@IdGenero, @Titulo)";

                //abre conexão com o bd
                con.Open();

                //delcara o sqlcommand, que serva para executar a instrução 
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    //passa o valor do parametro
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declaramos a query que será executada
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            //cria uma lista onde será guardado os filmes
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Filme.IdFilme, Filme.IdGenero, Filme.Titulo, Genero.Nome FROM Filme INNER JOIN Genero ON Genero.IdGenero = Filme.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            Titulo = rdr[2].ToString()
                        };

                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr[3].ToString()
                        };
                        filme.Genero = genero;
                        ListaFilmes.Add(filme);
                    }
                }
            }
            return ListaFilmes;
        }
    }
}
