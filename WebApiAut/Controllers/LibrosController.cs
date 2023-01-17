using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiAut.Entities;

namespace WebApiAut.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public LibrosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await dbContext.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);//query 

        }
        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existe = await dbContext.Autores.AnyAsync(x => x.Id == libro.AutorId); //verifica que el id que pasamos sea igual al que ya existe
            if(!existe)
            {
                return BadRequest("No existe autor con esa id");
            }
            dbContext.Add(libro);
            await dbContext.SaveChangesAsync();
            return Ok("Libro Agregado");
        }



    }
}
