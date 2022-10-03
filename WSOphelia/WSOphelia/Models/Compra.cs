﻿using System;
using System.Collections.Generic;

namespace WSOphelia.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Factura Factura { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
