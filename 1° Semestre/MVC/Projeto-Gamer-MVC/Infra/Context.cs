using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Gamer_MVC.Models;

namespace Projeto_Gamer_MVC.Infra
{
    public class Context : DbContext
    {
        //Dentro da Context fica as string de conexão, ou seja, ela vai conectar ao BD

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-VLQ1I1C; initial catalog = gamerTarde; User Id=sa; pwd=Senai@134; TrustServerCertificate = true");
            }
        }

        public DbSet<Jogador> Jogador {get;set;}
        public DbSet<Equipe> Equipe {get;set;}
    }
}