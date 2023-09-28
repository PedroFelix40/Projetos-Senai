using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Atualizar(Guid id, ComentarioEvento comentarioEvento);
        ComentarioEvento BuscarPorId(Guid id);
        void Cadastrar(ComentarioEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentarioEvento> Listar();
    }
}
