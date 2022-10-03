using WSOphelia.Models;
using WSOphelia.Repositories;

namespace WSOphelia.Services.impl
{
    public class ImplProductoService : IProductoService
    {
        private readonly facturacionOpheliaContext facturacionOpheliaContext;

        public ImplProductoService(facturacionOpheliaContext facturacionOpheliaContext)
        {
            this.facturacionOpheliaContext = facturacionOpheliaContext;
        }

        public Producto create(Producto producto)
        {
            facturacionOpheliaContext.Productos.Add(producto);
            facturacionOpheliaContext.SaveChanges();
            return producto;
        }

        public bool deleteById(int id)
        {
            var flag = true;
            var producto = findById(id);
            if (producto == null)
            {
                flag = false;
            }
            facturacionOpheliaContext.Productos.Attach(producto);
            facturacionOpheliaContext.Productos.Remove(producto);
            facturacionOpheliaContext.SaveChanges();
            return flag;
        }

        public Producto findById(int id)
        {
            return facturacionOpheliaContext.Productos.Find(id);
        }

        public List<Producto> getAll()
        {
            var list = new List<Producto>();
            list = facturacionOpheliaContext.Productos.ToList();
            return list;
        }

        public Producto update(Producto producto)
        {
            facturacionOpheliaContext.Productos.Update(producto);
            facturacionOpheliaContext.SaveChanges();
            return producto;
        }
    }
}
