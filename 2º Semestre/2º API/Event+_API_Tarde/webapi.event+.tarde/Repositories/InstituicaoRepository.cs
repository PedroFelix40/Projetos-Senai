using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

                if (instituicaoBuscada != null)
                {
                    instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                    instituicaoBuscada.Endereco = instituicao.Endereco;
                }

                _eventContext.Instituicao.Update(instituicaoBuscada);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Instituicao BuscarPorId(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id)!;

            return instituicaoBuscada;


        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Instituicao.Add(instituicao);

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
                Instituicao instituicaoBuscada = _eventContext.Instituicao.Find(id);

                if (instituicaoBuscada != null)
                {
                    _eventContext.Remove(instituicaoBuscada);
                }
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Instituicao> Listar()
        {
            try
            {
                return _eventContext.Instituicao.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
