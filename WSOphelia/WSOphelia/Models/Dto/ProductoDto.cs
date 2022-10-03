namespace WSOphelia.Models.Dto
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Compra Compras { get; set; }
    }
}
