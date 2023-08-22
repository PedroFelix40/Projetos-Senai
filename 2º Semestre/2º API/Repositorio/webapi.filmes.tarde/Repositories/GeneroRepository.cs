using System.Data.SqlClient;
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
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void deletar(int id)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo genero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos, onde será armazenados os generos
            List<GeneroDomain> ListaGeneros= new List<GeneroDomain>();

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
                    while(rdr.Read()) 
                    {
                        //Instancia um objeto do tipo GeneroDOmain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero à uma variavel, sendo ela o primeiro valor de uma tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propiedade nome o valor da coluna nome
                            Nome = Convert.ToString(rdr["Nome"])
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genero);
                    }
                }
                //Retorna a lista de generos 
                return ListaGeneros;
            }
        }
        
    }
}
