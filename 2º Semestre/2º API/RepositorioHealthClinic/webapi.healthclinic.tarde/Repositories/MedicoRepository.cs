using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;

        public MedicoRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Medico medico)
        {
            try
            {
                Medico medicoBuscado = _healthContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;

                if (medicoBuscado != null)
                {
                    medicoBuscado.Expediente = medico.Expediente;
                }

                _healthContext.Update(medicoBuscado);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Medico BuscarPorId(Guid id)
        {
            try
            {
                Medico medicoBuscado = _healthContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;

                return medicoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                _healthContext.Medico.Add(medico);

                _healthContext.SaveChanges();
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
                Medico medicoBuscado = _healthContext.Medico.FirstOrDefault(m => m.IdMedico == id)!;

                if (medicoBuscado != null)
                {
                    _healthContext.Medico.Remove(medicoBuscado);
                }
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
