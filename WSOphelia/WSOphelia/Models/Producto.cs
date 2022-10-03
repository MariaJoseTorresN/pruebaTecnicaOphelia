using System;
using System.Collections.Generic;

namespace WSOphelia.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Compras = new HashSet<Compra>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
