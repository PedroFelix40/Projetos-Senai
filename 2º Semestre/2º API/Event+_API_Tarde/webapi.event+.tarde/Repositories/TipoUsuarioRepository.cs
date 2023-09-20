using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
                }
                _eventContext.TipoUsuario.Update(tipoUsuarioBuscado);

                _eventContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuario = _eventContext.TipoUsuario.Find(id)!;

                return tipoUsuario;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuario = _eventContext.TipoUsuario.Find(id)!;

            if (tipoUsuario != null)
            {
                _eventContext.Remove(tipoUsuario);
            }
            _eventContext.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _eventContext.TipoUsuario.ToList();
        }
    }
}
