using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using webapi.event_.Domains;

namespace webapi.event_.Contexts
{
    /// <summary>
    /// Classe de contexto que faz referências as tabelas e define string de conexão
    /// </summary>
    public class Event_Context : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<TiposEvento> TiposEvento { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<ComentariosEvento> ComentariosEvento{ get; set; }

        public DbSet<Instituicao> Instituicao { get; set; }

        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        /// <summary>
        /// Define as opções de construção do banco
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // String de Conexão local SSMS
            //optionsBuilder.UseSqlServer("Server=NOTE15-S14; Database=event+_pedro; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");

            //String de Conexão SQL Database Azure

            optionsBuilder.UseSqlServer("Server=tcp:eventpedrog-server.database.windows.net,1433;Initial Catalog=eventPedroDatabase;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; User Id= eventpedrog-server; Pwd= Senai@134;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
