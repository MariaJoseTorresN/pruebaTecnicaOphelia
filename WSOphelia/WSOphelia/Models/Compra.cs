using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSOphelia.Models
{
    public partial class Compra
    {
        [Key]
        public int CompraId { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Factura? Factura { get; set; }
    }
}
