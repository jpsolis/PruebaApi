using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;

namespace PruebaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarroCompraController : ControllerBase
    {
        private readonly DataContext _context;

        public CarroCompraController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<CarroCompra>>> AddCarroCompra(CarroCompra carroCompra)
        {
            _context.CarroCompras.Add(carroCompra);
            await _context.SaveChangesAsync();

            return Ok(await _context.CarroCompras.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<CarroCompra>>> GetAllCarroCompras()
        {
            return Ok(await _context.CarroCompras.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarroCompra>> GetCarroCompra(int id)
        {
            var carroCompra = await _context.CarroCompras.FindAsync(id);
            if (carroCompra == null)
            {
                return BadRequest("Carro de Compra no encontrado.");
            }
            return Ok(carroCompra);
        }



        // PUT api/<RolController>/5
        [HttpPut]
        public async Task<ActionResult<CarroCompra>> UpdateCarroCompra(CarroCompra carroCompraModelo)
        {
            CarroCompra carroCompra = _context.CarroCompras.Find(carroCompraModelo.idCarroCompra);

            if (carroCompra == null)
            {
                return BadRequest("No encontrado");
            }

            try
            {
                carroCompra.DetalleCarro = carroCompraModelo.DetalleCarro is null ? carroCompra.DetalleCarro : carroCompraModelo.DetalleCarro;
                carroCompra.totalCompra = carroCompraModelo.totalCompra == 0 ? carroCompra.totalCompra : carroCompraModelo.totalCompra;
                _context.Attach(carroCompra);

                _context.Entry(carroCompra).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CarroCompra>> DeleteCarroCompra(int id)
        {
            var carroCompra = new CarroCompra() { idCarroCompra = id };
            _context.CarroCompras.Remove(carroCompra);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
