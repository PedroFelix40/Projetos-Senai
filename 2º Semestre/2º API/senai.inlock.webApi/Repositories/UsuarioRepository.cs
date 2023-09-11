using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        //public string StringConexao = "Data Source = DESKTOP-1CNOHAQ\\SQLEXPRESS; Initial Catalog = inlock_games_tarde; Integrated Security = true";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT Usuario.IdUsuario, Usuario.Email, TiposUsuario.IdTipoUsuario, TiposUsuario.Titulo FROM Usuario INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin,con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.Parameters.AddWithValue("@Senha", senha);
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString()
                        };
                        
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        usuario.tipoUsuarioDomain = tipoUsuario;
                        
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
