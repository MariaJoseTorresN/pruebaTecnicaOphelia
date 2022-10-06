using BE_Ophelia.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Repositories.Impl
{
    public class CompraRepository : ICompraRepository
    {
        private readonly OpheliaDbContext _context;

        public CompraRepository(OpheliaDbContext context)
        {
            _context = context;
        }
        public async Task<Compra> CreateCompra(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task DeleteCompra(Compra compra)
        {
            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Compra>> GetAllCompra()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<Compra> GetByIdCompra(int id)
        {
            return await _context.Compras.FindAsync(id);
        }

        public async Task UpdateCompra(Compra compra)
        {
            var compraA = await _context.Compras.FirstOrDefaultAsync(x => x.compraId == compra.compraId);

            if (compraA == null)
            {
                compraA.cantidad = compra.cantidad;
                compraA.precioPagado = compra.precioPagado;
                compraA.productoId = compra.productoId;
                compraA.facturaId = compra.facturaId;

                await _context.SaveChangesAsync();
            }
        }
    }
}
