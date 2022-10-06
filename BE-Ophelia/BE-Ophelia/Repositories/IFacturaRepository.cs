using BE_Ophelia.Models;

namespace BE_Ophelia.Repositories
{
    public interface IFacturaRepository
    {
        Task<List<Factura>> GetAllFacturas();
        Task<Factura> GetByIdFactura(int id);
        Task DeleteFactura(Factura factura);
        Task<Factura> CreateFactura(Factura factura);
        Task UpdateFactura(Factura factura);
    }
}
