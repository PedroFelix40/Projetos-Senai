using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Ultils;

namespace webapi.healthclinic.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;

        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            Usuario usuarioBuscado = _healthContext.Usuario
               .Select(u => new Usuario
               {
                   IdUsuario = u.IdUsuario,
                   Nome = u.Nome,
                   Email = u.Email,
                   Senha = u.Senha,

                   TipoUsuario = new TipoUsuario
                   {
                       IdTipoUsuario = u.IdTipoUsuario,
                       Titulo = u.TipoUsuario!.Titulo
                   }
               }).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)
            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                if (confere)
                {
                    return usuarioBuscado;
                }
            }
            return null!;
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

            _healthContext.Usuario.Add(usuario);

            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    _healthContext.Usuario.Remove(usuarioBuscado);

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
