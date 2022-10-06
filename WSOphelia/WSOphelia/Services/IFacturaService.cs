using WSOphelia.Models;

namespace WSOphelia.Services
{
    public interface IFacturaService
    {
        Task<List<Factura>> getAll();

        Task<Factura> create(Factura factura);

        Task<Factura> update(Factura factura);

        Task<Factura> findById(int id);

        Task<bool> deleteById(int id);
    }
}
