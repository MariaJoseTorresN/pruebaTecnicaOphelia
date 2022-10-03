namespace WSOphelia.Models.Dto
{
    public class FacturaDto
    {
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PrecioTotal { get; set; }

        public Cliente Cliente { get; set; }
        public Compra Compras { get; set; }
    }
}
