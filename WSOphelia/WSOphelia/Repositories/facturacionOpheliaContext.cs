using Microsoft.EntityFrameworkCore;
using WSOphelia.Models;

namespace WSOphelia.Repositories
{
    public class facturacionOpheliaContext : DbContext
    {
        public facturacionOpheliaContext(DbContextOptions<facturacionOpheliaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

    }

}
