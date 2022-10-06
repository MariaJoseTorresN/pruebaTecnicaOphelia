using System.ComponentModel.DataAnnotations.Schema;

namespace WSOphelia.Models.Dto
{
    public class CompraDto
    {
        public int CompraId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
