using System.ComponentModel.DataAnnotations;

namespace WSOphelia.Models
{
    public partial class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = null!;
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }

    }
}
