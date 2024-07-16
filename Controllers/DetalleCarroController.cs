using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarroController : ControllerBase
    {
        private readonly DataContext _context;

        public DetalleCarroController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<DetalleCarro>>> AddCarroCompra(DetalleCarro detalleCarro)
        {
            _context.DetalleCarros.Add(detalleCarro);
            await _context.SaveChangesAsync();

            return Ok(await _context.DetalleCarros.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<DetalleCarro>>> GetAllDetalleCarro()
        {
            return Ok(await _context.DetalleCarros.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCarro>> GetDetalleCarro(int id)
        {
            var detalleCarro = await _context.DetalleCarros.FindAsync(id);
            if (detalleCarro == null)
            {
                return BadRequest("Detalle no encontrado.");
            }
            return Ok(detalleCarro);
        }



        // PUT api/<RolController>/5
        [HttpPut]
        public async Task<ActionResult<CarroCompra>> UpdateDetalleCarro(DetalleCarro detalleCarroModelo)
        {
            DetalleCarro detalleCarro = _context.DetalleCarros.Find(detalleCarroModelo.idDetalleCarro);

            if (detalleCarro == null)
            {
                return BadRequest("No encontrado");
            }

            try
            {
                detalleCarro.Productos = detalleCarroModelo.Productos is null ? detalleCarro.Productos : detalleCarro.Productos;

                _context.Attach(detalleCarro);

                _context.Entry(detalleCarro).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DetalleCarro>> DeleteDetalleCarro(int id)
        {
            var detalleCarro = new DetalleCarro() { idDetalleCarro = id };
            _context.DetalleCarros.Remove(detalleCarro);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
