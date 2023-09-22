using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Atualizar(Guid id, PresencaEvento presencaEvento);
        PresencaEvento BuscarPorId(Guid id);
        void Cadastrar(PresencaEvento presencaEvento);
        void Deletar(Guid id);
        List<PresencaEvento> Listar();
    }
}
