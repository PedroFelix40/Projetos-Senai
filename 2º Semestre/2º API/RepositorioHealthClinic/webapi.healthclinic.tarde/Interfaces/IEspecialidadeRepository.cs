using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Atualizar(Guid id, Especialidade especialidade);
        Especialidade BuscarPorId(Guid id);
        void Cadastrar(Especialidade especialidade);
    }
}
