using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_prueba_tecnica.Models
{
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Pedidos Pedido { get; set; }
        public virtual Productos Producto { get; set; }
        public  decimal Cantitdad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
