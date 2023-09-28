    using Microsoft.AspNetCore.Http.HttpResults;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEvento = evento.TipoEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                }

                _eventContext.Evento.Update(eventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Select(e => new Evento()
                {
                    IdEvento = e.IdEvento,
                    NomeEvento = e.NomeEvento,
                    DataEvento = e.DataEvento,
                    Descricao = e.Descricao,

                    TipoEvento = new()
                    {
                        IdTipoEvento = e.TipoEvento.IdTipoEvento,
                        Titulo = e.TipoEvento.Titulo
                    },

                    Instituicao = new()
                    {
                        IdInstituicao = e.Instituicao.IdInstituicao,
                        CNPJ = e.Instituicao.CNPJ,
                        Endereco = e.Instituicao.Endereco,
                        NomeFantasia = e.Instituicao.NomeFantasia
                    }
                }).FirstOrDefault(e => e.IdEvento == id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id)!;

                if (eventoBuscado != null)
                {
                    _eventContext.Evento.Remove(eventoBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.Select(e => new Evento()
            {
                IdEvento = e.IdEvento,
                NomeEvento = e.NomeEvento,
                DataEvento = e.DataEvento,
                Descricao = e.Descricao,

                TipoEvento = new()
                {
                    IdTipoEvento = e.TipoEvento.IdTipoEvento,
                    Titulo = e.TipoEvento.Titulo
                },

                Instituicao = new()
                {
                    IdInstituicao = e.Instituicao.IdInstituicao,
                    CNPJ = e.Instituicao.CNPJ,
                    Endereco = e.Instituicao.Endereco,
                    NomeFantasia = e.Instituicao.NomeFantasia
                }
            }).ToList();
        }
    }
}
