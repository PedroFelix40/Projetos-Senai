﻿
using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DESKTOP-1CNOHAQ\\SQLEXPRESS; Initial Catalog = inlock_games_tarde; Integrated Security = true
            //optionsBuilder.UseSqlServer("Server=DESKTOP-2B634JF; Database=event+_tarde; User Id= sa; Pwd = Senai@134; TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-1CNOHAQ\\SQLEXPRESS; Database=event+_tarde; Integrated Security = true; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
