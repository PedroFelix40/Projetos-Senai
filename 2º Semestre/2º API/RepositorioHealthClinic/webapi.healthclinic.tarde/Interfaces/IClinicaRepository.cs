using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IClinicaRepository
    {
        void Atualizar(Guid id, Clinica clinica);
        Clinica BuscarPorId(Guid id);
        void Cadastrar(Clinica clinica);
    }
}
