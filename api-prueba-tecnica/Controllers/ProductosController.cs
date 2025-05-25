using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_prueba_tecnica.Data;
using api_prueba_tecnica.Models;
using Azure;

namespace api_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Productos>> Create([FromBody] Productos productos)
        {
            if (ModelState.IsValid)
            {
                var response = _context.Add(productos);
                await _context.SaveChangesAsync();
                var nuevoProducto = _context.Productos.Find(response.Entity.Id);
                return Ok(nuevoProducto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ObtenerProductosMasCaros")]
        public async Task<List<Productos>> ObtenerProductosMasCaros() 
        {
            var productos = ObtenerProductos();
             return productos = (from p in productos
                          orderby p.Precio descending
                          select p).Take(3).ToList();
        }

        private List<Productos> ObtenerProductos()
        {
            return _context.Productos.Select(productos => productos).ToList();
        }
    }
}
