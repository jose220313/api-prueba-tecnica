using api_prueba_tecnica.Data;
using api_prueba_tecnica.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace api_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<PedidoResponse> Post([FromBody] PedidoRequest req)
        {
            try
            {
                var cliente = _context.Clientes.SingleOrDefault(c => c.Id == req.ClienteId);

                var pedido = _context.Pedidos.Add(new Models.Pedidos
                {
                    Cliente = cliente,
                    Fecha = req.Fecha
                });

                await _context.SaveChangesAsync();


                foreach (var detalle in req.Detalles)
                {
                    var producto = _context.Productos.SingleOrDefault(p => p.Id == detalle.ProductoId);
                    _context.DetallePedidos.Add(new Models.DetallePedido
                    {
                        Pedido = _context.Pedidos.Find(pedido.Entity.Id),
                        Producto = producto,
                        Cantitdad = detalle.Cantidad,
                        PrecioUnitario = producto.Precio
                    });
                }
                await _context.SaveChangesAsync();

                return new PedidoResponse
                {
                    Id = pedido.Entity.Id,
                    ClienteId = pedido.Entity.Cliente.Id,
                    Fecha = pedido.Entity.Fecha,
                    Detalles = _context.DetallePedidos.Where(d => d.Pedido.Id == pedido.Entity.Id).ToList()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
