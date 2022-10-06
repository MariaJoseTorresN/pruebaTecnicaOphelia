using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Models
{
    public class OpheliaDbContext: DbContext
    {
        public OpheliaDbContext(DbContextOptions<OpheliaDbContext> options): base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
