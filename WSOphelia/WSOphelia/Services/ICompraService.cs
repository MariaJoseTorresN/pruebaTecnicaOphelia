using WSOphelia.Models;

namespace WSOphelia.Services
{
    public interface ICompraService
    {
        List<Compra> getAll();

        Compra create(Compra compra);

        Compra update(Compra compra);

        Compra findById(int id);

        bool deleteById(int id);
    }
}
