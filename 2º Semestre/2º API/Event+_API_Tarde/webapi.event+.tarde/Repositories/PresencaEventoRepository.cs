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
            PresencaEvento presencaEventoBuscada = _eventContext.PresencaEvento.Select(p => new PresencaEvento
            {
                IdPresencaEvento = p.IdPresencaEvento,
                Situacao = p.Situacao,

                Evento = new()
                {
                    IdEvento = p.Evento.IdEvento,
                    DataEvento = p.Evento.DataEvento,
                    NomeEvento = p.Evento.NomeEvento,
                    Descricao = p.Evento.Descricao,

                    TipoEvento = new()
                    {
                        IdTipoEvento = p.Evento.TipoEvento.IdTipoEvento,
                        Titulo = p.Evento.TipoEvento.Titulo
                    },

                    Instituicao = new()
                    {
                        IdInstituicao = p.Evento.Instituicao.IdInstituicao,
                        CNPJ = p.Evento.Instituicao.CNPJ,
                        Endereco = p.Evento.Instituicao.Endereco,
                        NomeFantasia = p.Evento.Instituicao.NomeFantasia
                    }
                },

                Usuario = new()
                {
                    IdUsuario = p.Usuario.IdUsuario,
                    Nome = p.Usuario.Nome
                }
            }).FirstOrDefault(p => p.IdPresencaEvento == id)!;

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
            return _eventContext.PresencaEvento.Select(p => new  PresencaEvento
            {
                IdPresencaEvento = p.IdPresencaEvento,
                Situacao = p.Situacao,

                Evento = new()
                {
                    IdEvento = p.Evento.IdEvento,
                    DataEvento = p.Evento.DataEvento,
                    NomeEvento = p.Evento.NomeEvento,
                    Descricao = p.Evento.Descricao,

                    TipoEvento = new()
                    {
                        IdTipoEvento = p.Evento.TipoEvento.IdTipoEvento,
                        Titulo = p.Evento.TipoEvento.Titulo
                    },

                    Instituicao = new()
                    {
                        IdInstituicao = p.Evento.Instituicao.IdInstituicao,
                        CNPJ = p.Evento.Instituicao.CNPJ,
                        Endereco = p.Evento.Instituicao.Endereco,
                        NomeFantasia = p.Evento.Instituicao.NomeFantasia
                    }
                },

                Usuario = new()
                {
                    IdUsuario = p.Usuario.IdUsuario,
                    Nome = p.Usuario.Nome
                }
            }).ToList();
        }
    }
}
