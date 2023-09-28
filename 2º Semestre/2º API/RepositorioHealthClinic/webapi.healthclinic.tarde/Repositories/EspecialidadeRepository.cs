using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;

        public EspecialidadeRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Especialidade especialidade)
        {
            try
            {
                Especialidade especialidadeBuscada = _healthContext.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id)!;

                if (especialidadeBuscada != null)
                {
                    especialidadeBuscada.TipoEspecialidade = especialidade.TipoEspecialidade;
                }

                _healthContext.Update(especialidadeBuscada);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Especialidade BuscarPorId(Guid id)
        {
            try
            {
            Especialidade especialidadeBuscada = _healthContext.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id)!;

            return especialidadeBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
            _healthContext.Especialidade.Add(especialidade);

            _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
