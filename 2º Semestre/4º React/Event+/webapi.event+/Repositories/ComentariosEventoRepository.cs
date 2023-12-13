﻿using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly Event_Context _context;

        public ComentariosEventoRepository()
        {
            _context = new Event_Context();
        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdComentarioEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComentariosEvento BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            IdUsuario = c.Usuario!.IdUsuario,
                            Nome = c.Usuario!.Nome,
                        },

                        Evento = new Evento
                        {
                            IdEvento = c.Evento.IdEvento,
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentariosEvento comentarioEvento)
        {
            try
            {
                _context.ComentariosEvento.Add(comentarioEvento);

                _context.SaveChanges();
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
                ComentariosEvento comentarioEventoBuscado = _context.ComentariosEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentariosEvento> Listar()
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                            DataEvento = c.Evento!.DataEvento,
                        }

                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ComentariosEvento> ListarSomenteExibe()
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                            DataEvento = c.Evento!.DataEvento,
                        }

                    }).Where(c => c.Exibe == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentariosEvento> ListarSomenteEvento(Guid id)
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                            DataEvento = c.Evento!.DataEvento,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentariosEvento> ListarSomenteEventoTrue(Guid id)
        {

            try
            {
                return _context.ComentariosEvento
                    .Select(c => new ComentariosEvento
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdComentarioEvento = c.IdComentarioEvento,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            Nome = c.Usuario!.Nome
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                            DataEvento = c.Evento!.DataEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}