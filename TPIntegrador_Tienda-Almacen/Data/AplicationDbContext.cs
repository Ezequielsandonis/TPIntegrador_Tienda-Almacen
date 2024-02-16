using Microsoft.EntityFrameworkCore;
using TPIntegrador_Tienda_Almacen.Modelos;

namespace TPIntegrador_Tienda_Almacen.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }

   
}
