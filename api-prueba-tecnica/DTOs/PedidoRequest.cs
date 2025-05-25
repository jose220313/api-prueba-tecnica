using System.ComponentModel.DataAnnotations;

namespace api_prueba_tecnica.DTOs
{
    public class PedidoRequest
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public List<DetallePedidoRequest> Detalles { get; set; }
    }
}
