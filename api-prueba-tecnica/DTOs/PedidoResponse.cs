using api_prueba_tecnica.Models;

namespace api_prueba_tecnica.DTOs
{
    public class PedidoResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetallePedido> Detalles { get; set; }

    }
}
