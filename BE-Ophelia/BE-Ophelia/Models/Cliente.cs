using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ophelia.Models
{
    public class Cliente
    {
        [Key]
        public int clienteId { get; set; }
        [Required, MaxLength(10)]
        public string cedula { get; set; }
        [Required, MaxLength(50)]
        public string nombre { get; set; }
        [Required, MaxLength(50)]
        public string apellido { get; set; }
        [Required]
        public DateTime fechaNacimiento { get; set; }
        [Required, MaxLength(10)]
        public string celular { get; set; }
        [Required, MaxLength(128)]
        public string correo { get; set; }

    }
}
