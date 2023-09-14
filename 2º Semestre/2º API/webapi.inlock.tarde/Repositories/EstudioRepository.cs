using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id);

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            Estudio estudio = ctx.Estudios.Find(id);

            return estudio;
        }

        public void Cadastrar(Estudio estudio)
        {
            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();  
        }

        public void Deletar(Guid id)
        {
            Estudio estudio = ctx.Estudios.Find(id);
            
            if (estudio != null)
            {
                ctx.Estudios.Remove(estudio);
            }
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {

            //throw new NotImplementedException();
             return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
