using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_prueba_tecnica.Data;
using api_prueba_tecnica.Models;

namespace api_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> Create([FromBody] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                var response = _context.Add(clientes);
                await _context.SaveChangesAsync();
                var nuevoCliente = _context.Clientes.Find(response.Entity.Id);
                return Ok(nuevoCliente);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ExtraerCodigoDeCliente")]
        public async Task<string> ExtraerCodigoDeCliente(string input, string clave)
        {
            return input.Split(clave)[1].Split(' ')[0].Replace(";", "");
        }
    }
}
