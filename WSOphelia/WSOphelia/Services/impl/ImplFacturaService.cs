using WSOphelia.Models;
using WSOphelia.Repositories;

namespace WSOphelia.Services.impl
{
    public class ImplFacturaService : IFacturaService
    {
        private readonly facturacionOpheliaContext facturacionOpheliaContext;

        public ImplFacturaService(facturacionOpheliaContext facturacionOpheliaContext)
        {
            this.facturacionOpheliaContext = facturacionOpheliaContext;
        }

        public Factura create(Factura factura)
        {
            facturacionOpheliaContext.Facturas.Add(factura);
            facturacionOpheliaContext.SaveChanges();
            return factura;
        }

        public bool deleteById(int id)
        {
            var flag = true;
            var factura = findById(id);
            if (factura == null)
            {
                flag = false;
            }
            facturacionOpheliaContext.Facturas.Attach(factura);
            facturacionOpheliaContext.Facturas.Remove(factura);
            facturacionOpheliaContext.SaveChanges();
            return flag;
        }

        public Factura findById(int id)
        {
            return facturacionOpheliaContext.Facturas.Find(id);
        }

        public List<Factura> getAll()
        {
            var list = new List<Factura>();
            list = facturacionOpheliaContext.Facturas.ToList();
            return list;
        }

        public Factura update(Factura factura)
        {
            facturacionOpheliaContext.Facturas.Update(factura);
            facturacionOpheliaContext.SaveChanges();
            return factura;
        }
    }
}
