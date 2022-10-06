using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ophelia.Models
{
    public class Compra
    {
        [Key]
        public int compraId { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public int precioPagado { get; set; }
        public int productoId { get; set; }
        [ForeignKey("productoId")]
        public Producto cliente { get; set; }

        public int facturaId { get; set; }
        [ForeignKey("facturaId")]
        public Factura factura { get; set; }
    }
}
