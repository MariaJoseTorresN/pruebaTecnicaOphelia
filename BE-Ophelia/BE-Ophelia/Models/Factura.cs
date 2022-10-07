using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ophelia.Models
{
    public class Factura
    {
        [Key]
        public int facturaId { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public int precioTotal { get; set; }
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        public Cliente? cliente { get; set; }

    }
}
