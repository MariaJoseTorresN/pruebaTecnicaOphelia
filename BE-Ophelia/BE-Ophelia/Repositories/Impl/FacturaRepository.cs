using BE_Ophelia.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Repositories.Impl
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly OpheliaDbContext _context;

        public FacturaRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public async Task<Factura> CreateFactura(Factura factura)
        {
            factura.cliente = await _context.Clientes.FindAsync(keyValues: factura.clienteId);
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task DeleteFactura(Factura factura)
        {
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Factura>> GetAllFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<Factura> GetByIdFactura(int id)
        {
            return await _context.Facturas.FindAsync(id);
        }

        public async Task UpdateFactura(Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChangesAsync();
        }
    }
}
