using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Atualizar(Guid id, Paciente paciente);
        Paciente BuscarPorId(Guid id);
        void Cadastrar(Paciente paciente);
        void Deletar(Guid id);
    }
}
