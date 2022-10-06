using BE_Ophelia.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Repositories.Impl
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly OpheliaDbContext _context;

        public ProductoRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task DeleteProducto(Producto producto)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetByIdProducto(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task UpdateProducto(Producto producto)
        {
            var productoA = await _context.Productos.FirstOrDefaultAsync(x => x.productoId == producto.productoId);

            if (productoA == null)
            {
                productoA.nombre = producto.nombre;
                productoA.precio = producto.precio;
                productoA.cantidad = producto.cantidad;

                await _context.SaveChangesAsync();
            }
        }
    }
}
