using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaEventoBuscada = _eventContext.PresencaEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;

            if (presencaEventoBuscada != null)
            {
                presencaEventoBuscada.Situacao = presencaEvento.Situacao;
            }

            _eventContext.PresencaEvento.Update(presencaEventoBuscada);

            _eventContext.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            PresencaEvento presencaEventoBuscada = _eventContext.PresencaEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;

            return presencaEventoBuscada;
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            _eventContext.PresencaEvento.Add(presencaEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaEventoBuscada = _eventContext.PresencaEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;

            if (presencaEventoBuscada != null)
            {
                _eventContext.Remove(presencaEventoBuscada);
            }

            _eventContext.SaveChanges();
        }

        public List<PresencaEvento> Listar()
        {
            return _eventContext.PresencaEvento.ToList();
        }
    }
}
