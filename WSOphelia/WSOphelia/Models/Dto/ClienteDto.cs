namespace WSOphelia.Models.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }

    }
}
