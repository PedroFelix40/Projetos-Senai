using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, ComentarioEvento comentarioEvento)
        {
            ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.FirstOrDefault(c => c.IdComentarioEvento == id)!;
            
            if (comentarioBuscado != null)
            {
                comentarioBuscado.Descricao = comentarioEvento.Descricao;
                comentarioBuscado.Exibe = comentarioEvento.Exibe;
            }

            _eventContext.Update(comentarioBuscado);

            _eventContext.SaveChanges();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.Select(c =>  new ComentarioEvento
            {
                IdComentarioEvento = c.IdComentarioEvento,
                Descricao = c.Descricao,

                Usuario = new()
                {
                    IdUsuario = c.Usuario!.IdUsuario,
                    Nome = c.Usuario.Nome,

                    TipoUsuario = new()
                    {
                        IdTipoUsuario = c.Usuario.TipoUsuario!.IdTipoUsuario,
                        Titulo = c.Usuario.TipoUsuario.Titulo
                    }
                },

                Evento = new()
                {
                    IdEvento = c.Evento!.IdEvento,
                    NomeEvento = c.Evento.NomeEvento,
                    DataEvento = c.Evento.DataEvento,
                    Descricao = c.Evento.Descricao,

                    TipoEvento = new()
                    {
                        IdTipoEvento = c.Evento.TipoEvento!.IdTipoEvento,
                        Titulo = c.Evento.TipoEvento.Titulo
                    },

                    Instituicao = new()
                    {
                        IdInstituicao = c.Evento.Instituicao!.IdInstituicao,
                        NomeFantasia = c.Evento.Instituicao.NomeFantasia
                    }
                }
            }).FirstOrDefault(c => c.IdComentarioEvento == id)!;

            return comentarioBuscado;
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

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
                ComentarioEvento comentarioBuscado = _eventContext.ComentarioEvento.FirstOrDefault(c => c.IdComentarioEvento == id)!;

                if (comentarioBuscado != null)
                {
                    _eventContext.Remove(comentarioBuscado);
                }

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            return _eventContext.ComentarioEvento.Select(c => new ComentarioEvento
            {
                IdComentarioEvento = c.IdComentarioEvento,
                Descricao = c.Descricao,

                Usuario = new()
                {
                    IdUsuario = c.Usuario!.IdUsuario,
                    Nome = c.Usuario.Nome,
                    
                    TipoUsuario = new()
                    {
                        IdTipoUsuario = c.Usuario.TipoUsuario!.IdTipoUsuario,
                        Titulo = c.Usuario.TipoUsuario.Titulo
                    }
                },

                Evento = new()
                {
                    IdEvento = c.Evento!.IdEvento,
                    NomeEvento = c.Evento.NomeEvento,
                    DataEvento = c.Evento.DataEvento,
                    Descricao = c.Evento.Descricao,

                    TipoEvento = new()
                    {
                        IdTipoEvento = c.Evento.TipoEvento!.IdTipoEvento,
                        Titulo = c.Evento.TipoEvento.Titulo
                    },

                    Instituicao = new()
                    { 
                        IdInstituicao = c.Evento.Instituicao!.IdInstituicao,
                        NomeFantasia = c.Evento.Instituicao.NomeFantasia
                    }
                }
            }).ToList();
        }
    }
}
