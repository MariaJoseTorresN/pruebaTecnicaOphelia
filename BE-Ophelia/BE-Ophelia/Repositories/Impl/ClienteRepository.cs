using BE_Ophelia.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_Ophelia.Repositories.Impl
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly OpheliaDbContext _context;

        public ClienteRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdCliente(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            var clienteA = await _context.Clientes.FirstOrDefaultAsync(x => x.clienteId == cliente.clienteId);

            if(clienteA == null)
            {
                clienteA.cedula = cliente.cedula;
                clienteA.nombre = cliente.nombre;
                clienteA.apellido = cliente.apellido;
                clienteA.fechaNacimiento = cliente.fechaNacimiento;
                clienteA.celular = cliente.celular;
                clienteA.correo = cliente.correo;

                await _context.SaveChangesAsync();
            }

        }
    }
}
