using BE_Ophelia.Models;

namespace BE_Ophelia.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetByIdProducto(int id);
        Task DeleteProducto(Producto producto);
        Task<Producto> CreateProducto(Producto producto);
        Task UpdateProducto(Producto producto);
    }
}
