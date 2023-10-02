using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;

        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }

        public Consulta BuscarPorId(Guid id)
        {
            Consulta consultaBuscada = _healthContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;

            return consultaBuscada;
        }

        public void CadastrarConsulta(Consulta consulta)
        {
            _healthContext.Consulta.Add(consulta);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = _healthContext.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;

            if (consultaBuscada != null)
            {
                _healthContext.Consulta.Remove(consultaBuscada);
            }

            _healthContext.SaveChanges();
        }

        public List<Consulta> ListarConsultasAdm()
        {
            return _healthContext.Consulta.ToList();
        }

        public List<Consulta> ListarConsultasMedico(Guid id)
        {
            return _healthContext.Consulta.Where(m => m.IdMedico == id).ToList();
        }

        public List<Consulta> ListarConsultasPaciente(Guid id)
        {
            return _healthContext.Consulta.Where(m => m.IdPaciente == id).ToList();
        }
    }
}
