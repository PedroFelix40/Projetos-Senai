using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealthContext _healthContext;

        public ComentarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _healthContext.Comentario.FirstOrDefault(c => c.IdComentario == id)!;

                return comentarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cadastrar(Comentario comentario)
        {
            _healthContext.Comentario.Add(comentario);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Comentario comentarioBuscado = _healthContext.Comentario.FirstOrDefault(c => c.IdComentario == id)!;

            if (comentarioBuscado != null)
            {
                _healthContext.Comentario.Remove(comentarioBuscado);
            }

            _healthContext.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return _healthContext.Comentario.ToList();
        }
    }
}
