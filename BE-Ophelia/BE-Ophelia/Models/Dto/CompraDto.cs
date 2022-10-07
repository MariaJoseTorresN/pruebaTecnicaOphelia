using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_Ophelia.Models.Dto
{
    public class CompraDto
    {
        public int compraId { get; set; }
        public int cantidad { get; set; }
        public int precioPagado { get; set; }
        public int productoId { get; set; }
        public Producto producto { get; set; }
        public int facturaId { get; set; }
        public Factura factura { get; set; }
    }
}
