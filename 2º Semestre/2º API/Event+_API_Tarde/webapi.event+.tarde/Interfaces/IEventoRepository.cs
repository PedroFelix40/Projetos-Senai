using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Atualizar(Guid id, Evento evento);
        Evento BuscarPorId(Guid id);
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        List<Evento> Listar();
    }
}
