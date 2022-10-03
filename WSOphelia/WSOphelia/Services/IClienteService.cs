using WSOphelia.Models;

namespace WSOphelia.Services
{
    public interface IClienteService
    {
        List<Cliente> getAll();

        Cliente create(Cliente cliente);

        Cliente update(Cliente cliente);

        Cliente findById(int id);

        bool deleteById(int id);
    }
}
