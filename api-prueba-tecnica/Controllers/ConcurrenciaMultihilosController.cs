using Microsoft.AspNetCore.Mvc;

namespace api_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcurrenciaMultihilosController : ControllerBase
    {
        [HttpPost]
        public async Task<List<Resultado>> Post(List<string> rutasArchivos)
        {
            var resultados = new List<Resultado>();

            foreach (var ruta in rutasArchivos)
            {
                using StreamReader sr = new StreamReader(ruta);
                int suma = 0;
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    suma += int.Parse(line);
                }

                resultados.Add(new Resultado { Ruta = ruta, Total = suma });
            }

            return resultados;

        }

        public class Resultado
        {
            public string Ruta { get; set; }
            public int Total { get; set; }
        }
    }
}
