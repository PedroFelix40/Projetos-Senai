using ApiInventario.Domains;
using Microsoft.EntityFrameworkCore;

namespace ApiInventario.Contexts
{
    public class InventarioContext : DbContext
    {
        public InventarioContext()
        {

        }

        public InventarioContext(DbContextOptions<InventarioContext> options)
           : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        //private readonly string StringConexao = "Data Source=NOTE14-SALA19; initial catalog=ApiInventario; TrustServerCertificate=true; user Id = sa; pwd=Senai@134";

        private readonly string StringConexao = "Data Source=DESKTOP-1CNOHAQ\\SQLEXPRESS; initial catalog=ApiInventario; TrustServerCertificate=true; user Id = sa; pwd=2502";

        // StringConexao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(StringConexao);

    }
}
