using Microsoft.EntityFrameworkCore;
using DesafioJAP.Models;

namespace DesafioJAP.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
