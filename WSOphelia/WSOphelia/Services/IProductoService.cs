using WSOphelia.Models;

namespace WSOphelia.Services
{
    public interface IProductoService
    {
        List<Producto> getAll();

        Producto create(Producto producto);

        Producto update(Producto producto);

        Producto findById(int id);

        bool deleteById(int id);
    }
}
