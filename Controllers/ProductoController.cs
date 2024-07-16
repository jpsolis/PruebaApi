using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Producto>>> AddProducto(Producto prod)
        {
            _context.Productos.Add(prod);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }



        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetAllProductos()
        {
            return Ok(await _context.Productos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var prod = await _context.Productos.FindAsync(id);
            if (prod == null)
            {
                return BadRequest("Producto no encontrado.");
            }
            return Ok(prod);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var prod = new Producto() { idProducto = id };
            _context.Productos.Remove(prod);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPut("{id:int}")]
        [HttpPut]
        public async Task<ActionResult<Producto>> UpdateProducto(Producto prodModelo)
        {
            Producto prod = _context.Productos.Find(prodModelo.idProducto);

            if (prod == null)
            {
                return BadRequest("No encontrado");
            }

            try
            {
                prod.descripcion = prodModelo.descripcion is null ? prod.descripcion : prodModelo.descripcion;
                prod.precio = prodModelo.precio == 0 ? prod.precio : prodModelo.precio;
                prod.imgPath = prodModelo.imgPath is null ? prod.imgPath : prodModelo.imgPath;

                _context.Attach(prod);

                //_dbcontext.TabAgregados.Update(objeto);
                _context.Entry(prod).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }


            //var producto = await _context.Productos.FindAsync(prodId);

            //if (producto != null)
            //{
            //    producto.descripcion = prodModelo.descripcion;
            //    producto.precio = prodModelo.precio;

            //    await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    return NotFound();
            //}

            //return Ok();

        }
    }
}
