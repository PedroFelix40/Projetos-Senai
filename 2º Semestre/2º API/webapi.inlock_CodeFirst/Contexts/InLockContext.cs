using Microsoft.EntityFrameworkCore;
using webapi.inlock_CodeFirst.Domains;

namespace webapi.inlock_CodeFirst.Contexts
{
    public class InLockContext : DbContext
    {

        public DbSet<TipoUsuario> tipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio>  Estudio { get; set; }
        public DbSet<Jogo>  Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2B634JF; Database=inlock_games_codeFirst_tarde; User Id= sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
