using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Data;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Rol>>> AddRol(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetAllRoles()
        {
            return Ok(await _context.Roles.ToListAsync());
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var prod = await _context.Roles.FindAsync(id);
            if (prod == null)
            {
                return BadRequest("Rol no encontrado.");
            }
            return Ok(prod);
        }



        // PUT api/<RolController>/5
        [HttpPut]
        public async Task<ActionResult<Rol>> UpdateRol(Rol rolModelo)
        {
            Rol rol = _context.Roles.Find(rolModelo.idRol);

            if (rol == null)
            {
                return BadRequest("No encontrado");
            }

            try
            {
                rol.rolDescripcion = rolModelo.rolDescripcion is null ? rol.rolDescripcion : rolModelo.rolDescripcion;

                _context.Attach(rol);

                _context.Entry(rol).State = EntityState.Modified;
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }

        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var rol = new Rol() { idRol = id };
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
