using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Atualizar (Guid id, TipoUsuario tipoUsuario);
        TipoUsuario BuscarPorId(Guid id);
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        List<TipoUsuario> Listar();
    }
}
