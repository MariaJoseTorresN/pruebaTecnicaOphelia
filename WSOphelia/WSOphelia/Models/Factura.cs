using System;
using System.Collections.Generic;

namespace WSOphelia.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Compras = new HashSet<Compra>();
        }

        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
