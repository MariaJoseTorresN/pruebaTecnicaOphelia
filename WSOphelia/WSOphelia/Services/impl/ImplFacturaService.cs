using WSOphelia.Models;
using WSOphelia.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WSOphelia.Services.impl
{
    public class ImplFacturaService : IFacturaService
    {
        private readonly facturacionOpheliaContext facturacionOpheliaContext;

        public ImplFacturaService(facturacionOpheliaContext _facturacionOpheliaContext)
        {
            facturacionOpheliaContext = _facturacionOpheliaContext;
        }

        public Task<Factura> create(Factura factura)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Factura> findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Factura>> getAll()
        {
            List<Factura> facturas = await facturacionOpheliaContext.Facturas.OrderByDescending(f => f.FacturaId).Include(f => f.Cliente).ToListAsync();
            return facturas;
        }

        public Task<Factura> update(Factura factura)
        {
            throw new NotImplementedException();
        }
    }
}
