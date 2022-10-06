namespace BE_Ophelia.Models.Dto
{
    public class ClienteDto
    {
        public int clienteId { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
    }
}
