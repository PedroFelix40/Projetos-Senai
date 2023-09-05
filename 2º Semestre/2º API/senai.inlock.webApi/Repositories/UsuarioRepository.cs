using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interface;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public string StringConexao = "Data Source = DESKTOP-2B634JF; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        public UsuarioDomain Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
