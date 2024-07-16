using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly DataContext _context;
        public StockController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Stock>>> AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Stock>>> GetAllStocks()
        {
            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return BadRequest("Producto no encontrado.");
            }
            return Ok(stock);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Rol>> DeleteStock(int id)
        {
            var stock = new Stock() { idStock = id };
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Rol>> UpdateStock(Stock stockModelo)
        {
            Stock stock = _context.Stocks.Find(stockModelo.idStock);

            if (stock == null)
            {
                return BadRequest("No encontrado");
            }

            try
            {
                stock.stockDisponible = stockModelo.stockDisponible == 0 ? stock.stockDisponible : stockModelo.stockDisponible;

                _context.Attach(stock);

                _context.Entry(stock).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }

        }
    }
}
