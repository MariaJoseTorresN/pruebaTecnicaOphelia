using BE_Ophelia.Models;

namespace BE_Ophelia.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetByIdCliente(int id);
        Task DeleteCliente(Cliente cliente);
        Task<Cliente> CreateCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
    }
}
