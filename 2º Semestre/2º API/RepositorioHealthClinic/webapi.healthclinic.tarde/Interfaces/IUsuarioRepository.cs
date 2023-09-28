using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscarPorEmailESenha(string email, string senha);
        Usuario BuscarPorId(Guid id);
        void Deletar(Guid id);
    }
}
