using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.OpenApi.Extensions;
using WebAPINET8.Database;
using WebAPINET8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPINET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarrerasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Carreras
        [HttpGet]
        public async Task<ActionResult> Get()

        {

            var result = await _context.Carreras.ToListAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/Carreras/id

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Carreras.SingleOrDefaultAsync(x => x.Id == id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        // GET api/Carreras/id/Materias
        [HttpGet("{id}/Materias")]
        public async Task<ActionResult<IEnumerable<string>>> GetMaterias(int id)

        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
                return NotFound();

            return Ok(carrera.Materias);
        }
        // GET api/Carreras/id/Especialidades
        [HttpGet("{id}/Especialidades")]
        public async Task<ActionResult<IEnumerable<string>>> GetEspecialidades(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
                return NotFound();

            return Ok(carrera.Especialidades);
        }


        // POST api/Carreras
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Carrera carrera)
            
        {
            await _context.Carreras.AddAsync(carrera);
            _context.SaveChanges();
            return Ok(carrera);
        }

        // PUT api/Carreras/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Carrera carrera)
            
        {
            var carreraInfo = _context.Carreras.SingleOrDefault(x => x.Id == id);
            if(carreraInfo ==null)
                return NotFound();
            carreraInfo.Id = id;
            carreraInfo.Name = carrera.Name;
            carreraInfo.Perfil = carrera.Perfil;
            carreraInfo.Materias = carrera.Materias;
            carreraInfo.Especialidades = carrera.Especialidades;
            

            _context.Attach(carreraInfo);
            await _context.SaveChangesAsync();  
            return Ok(carrera);

        }

        // DELETE api/Carreras/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customerInfo = _context.Carreras.SingleOrDefault(x => x.Id == id);
            if (customerInfo == null)
                return NotFound();
            _context.Carreras.Remove(customerInfo);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
