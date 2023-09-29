using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;

        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Paciente paciente)
        {
            try
            {
                Paciente pacienteBuscada = _healthContext.Paciente.FirstOrDefault(p => p.IdPaciente == id)!;

                if (pacienteBuscada != null)
                {
                    pacienteBuscada.Telefone = paciente.Telefone;
                    pacienteBuscada.Endereco = paciente.Endereco;
                }
                _healthContext.Update(pacienteBuscada);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscada = _healthContext.Paciente.FirstOrDefault(p => p.IdPaciente == id)!;

                return pacienteBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                _healthContext.Paciente.Add(paciente);

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
                Paciente pacienteBuscada = _healthContext.Paciente.FirstOrDefault(p => p.IdPaciente == id)!;

                if (pacienteBuscada != null)
                {
                    _healthContext.Paciente.Remove(pacienteBuscada);
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
