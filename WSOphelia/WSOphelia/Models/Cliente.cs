using System;
using System.Collections.Generic;

namespace WSOphelia.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int ClienteId { get; set; }
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
