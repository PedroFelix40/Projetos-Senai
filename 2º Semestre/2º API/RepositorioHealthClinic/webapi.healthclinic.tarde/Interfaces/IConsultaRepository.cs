using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IConsultaRepository
    {
        List<Consulta> ListarConsultasAdm();
        List<Consulta> ListarConsultasPaciente(Guid id);
        List<Consulta> ListarConsultasMedico(Guid id);
        void CadastrarConsulta(Consulta consulta);
        void Deletar(Guid id);
        Consulta BuscarPorId(Guid id);
    }
}
