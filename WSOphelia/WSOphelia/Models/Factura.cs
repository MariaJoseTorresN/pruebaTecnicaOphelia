using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSOphelia.Models
{
    public partial class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal PrecioTotal { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }
    }
}
