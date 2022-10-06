namespace BE_Ophelia.Models.Dto
{
    public class FacturaDto
    {
        public int facturaId { get; set; }
        public DateTime fecha { get; set; }
        public int precioTotal { get; set; }
        public int clienteId { get; set; }
        public Cliente cliente { get; set; }
    }
}
