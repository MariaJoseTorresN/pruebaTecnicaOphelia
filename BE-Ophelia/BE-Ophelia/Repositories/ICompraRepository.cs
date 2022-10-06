using BE_Ophelia.Models;

namespace BE_Ophelia.Repositories
{
    public interface ICompraRepository
    {
        Task<List<Compra>> GetAllCompra();
        Task<Compra> GetByIdCompra(int id);
        Task DeleteCompra(Compra compra);
        Task<Compra> CreateCompra(Compra compra);
        Task UpdateCompra(Compra compra);
    }
}
