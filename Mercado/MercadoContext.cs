using Mercado.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado
{
    public class MercadoContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var endereco = "Server=(localdb)\\mssqllocaldb;Database=MercadoDB;Trusted_Connection=true;";
            optionsBuilder.UseSqlServer(endereco);
        }
    }
}
