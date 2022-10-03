using WSOphelia.Models;

namespace WSOphelia.Services
{
    public interface IFacturaService
    {
        List<Factura> getAll();

        Factura create(Factura factura);

        Factura update(Factura factura);

        Factura findById(int id);

        bool deleteById(int id);
    }
}
