using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Interface
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
