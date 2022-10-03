using WSOphelia.Models;
using WSOphelia.Repositories;

namespace WSOphelia.Services.impl
{
    public class ImplCompraService : ICompraService
    {
        private readonly facturacionOpheliaContext facturacionOpheliaContext;

        public ImplCompraService(facturacionOpheliaContext facturacionOpheliaContext)
        {
            this.facturacionOpheliaContext = facturacionOpheliaContext;
        }

        public Compra create(Compra compra)
        {
            facturacionOpheliaContext.Compras.Add(compra);
            facturacionOpheliaContext.SaveChanges();
            return compra;
        }

        public bool deleteById(int id)
        {
            var flag = true;
            var compra = findById(id);
            if (compra == null)
            {
                flag = false;
            }
            facturacionOpheliaContext.Compras.Attach(compra);
            facturacionOpheliaContext.Compras.Remove(compra);
            facturacionOpheliaContext.SaveChanges();
            return flag;
        }

        public Compra findById(int id)
        {
            return facturacionOpheliaContext.Compras.Find(id);
        }

        public List<Compra> getAll()
        {
            var list = new List<Compra>();
            list = facturacionOpheliaContext.Compras.ToList();
            return list;
        }

        public Compra update(Compra compra)
        {
            facturacionOpheliaContext.Compras.Update(compra);
            facturacionOpheliaContext.SaveChanges();
            return compra;
        }
    }
}
