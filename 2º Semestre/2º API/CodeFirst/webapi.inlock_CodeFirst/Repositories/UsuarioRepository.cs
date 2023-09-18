using Azure.Core;
using Microsoft.EntityFrameworkCore;
using webapi.inlock_CodeFirst.Contexts;
using webapi.inlock_CodeFirst.Domains;
using webapi.inlock_CodeFirst.Interface;
using webapi.inlock_CodeFirst.Utils;

namespace webapi.inlock_CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InLockContext ctx;
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.Include(u => u.TipoUsuario).FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
