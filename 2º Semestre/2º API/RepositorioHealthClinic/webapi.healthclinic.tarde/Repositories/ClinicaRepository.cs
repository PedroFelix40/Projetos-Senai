using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        
        private readonly HealthContext _healthContext;

        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            try
            {
            Clinica clinicaBuscada = _healthContext.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.HoraAbertura = clinica.HoraAbertura;
                clinicaBuscada.HoraFechamento = clinica.HoraFechamento;
            }

                _healthContext.Update(clinicaBuscada);

                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Clinica BuscarPorId(Guid id)
        {
            Clinica clinicaBuscada = _healthContext.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

            return clinicaBuscada;
        }

        public void Cadastrar(Clinica clinica)
        {
            _healthContext.Clinica.Add(clinica);

            _healthContext.SaveChanges();
        }
    }
}
