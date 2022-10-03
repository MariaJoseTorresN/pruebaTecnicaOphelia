using WSOphelia.Models;
using WSOphelia.Repositories;

namespace WSOphelia.Services.impl
{
    public class ImplClienteService : IClienteService
    {
        private readonly facturacionOpheliaContext facturacionOpheliaContext;

        public ImplClienteService (facturacionOpheliaContext facturacionOpheliaContext)
        {
            this.facturacionOpheliaContext = facturacionOpheliaContext;
        }

        public Cliente create(Cliente cliente)
        {
            facturacionOpheliaContext.Clientes.Add(cliente);
            facturacionOpheliaContext.SaveChanges();
            return cliente;
        }

        public Cliente findById(int id)
        {
            return facturacionOpheliaContext.Clientes.Find(id);
        }

        public List<Cliente> getAll()
        {
            var list = new List<Cliente>();
            list = facturacionOpheliaContext.Clientes.ToList();
            return list;
        }

        public bool deleteById(int id)
        {
            var flag = true;
            var cliente = findById(id);
            if (cliente == null) { 
                flag = false;
            }
            facturacionOpheliaContext.Clientes.Attach(cliente);
            facturacionOpheliaContext.Clientes.Remove(cliente);
            facturacionOpheliaContext.SaveChanges();
            return flag;
        }

        public Cliente update(Cliente cliente)
        {
            facturacionOpheliaContext.Clientes.Update(cliente);
            facturacionOpheliaContext.SaveChanges();
            return cliente;
        }
    }
}
