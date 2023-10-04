using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        Comentario BuscarPorId(Guid id);
        void Deletar(Guid id);
        List<Comentario> Listar();
    }
}
