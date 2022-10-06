using System.ComponentModel.DataAnnotations;

namespace BE_Ophelia.Models
{
    public class Producto
    {
        [Key]
        public int productoId { get; set; }
        [Required, MaxLength(128)]
        public string nombre { get; set; }
        [Required]
        public float precio { get; set; }
        [Required]
        public int cantidad { get; set; }
    }
}
