namespace api_prueba_tecnica.DTOs
{
    public class DetallePedidoRequest
    {
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
}
