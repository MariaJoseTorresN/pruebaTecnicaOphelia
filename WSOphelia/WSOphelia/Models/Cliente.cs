using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSOphelia.Models
{
    public partial class Cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClienteId { get; set; }
        [Required, MaxLength(10)]
        public string Cedula { get; set; } = null!;
        [Required, MaxLength(128)]
        public string Nombre { get; set; } = null!;
        [Required, MaxLength(128)]
        public string Apellido { get; set; } = null!;
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required, MaxLength(10)]
        public string Celular { get; set; } = null!;
        [Required, MaxLength(150)]
        public string Correo { get; set; } = null!;

    }
}
