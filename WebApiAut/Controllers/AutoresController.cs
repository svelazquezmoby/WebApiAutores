using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAut.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiAut.Controllers
{
    [ApiController]
    [Route("api/autores")]  
    
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AutoresController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]//atributos
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await dbContext.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Autor>> PrimerAutor()
        {
            return await dbContext.Autores.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var existe =  await dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);//retorna null si no lo encuentra
            if (existe == null)
            {
                return NotFound("el id no existe");
            }
            return existe;
        }

        [HttpGet("{nombre}")]//busqueda por nombre
        public async Task<ActionResult<Autor>> Get([FromRoute] string nombre)
        {
            var existe = await dbContext.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));//retorna null si no lo encuentra
            if (existe == null)
            {
                return NotFound("el id no existe");
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Autor autor)
        {
            var existeIgualNombre= await dbContext.Autores.AnyAsync(x => x.Nombre == autor.Nombre);
            if (existeIgualNombre)
            {
                return BadRequest($"Ya existe el nombre {autor.Nombre}");
            }
            dbContext.Add(autor);
            await dbContext.SaveChangesAsync();
            return Ok("Autor Agregado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id no coincide");
            }

            var existe = await dbContext.Autores.AnyAsync(x => x.Id == id); //verifica que el id que pasamos sea igual al que ya existe
            if (!existe)
            {
                return NotFound("El id no existe");
            }
            dbContext.Update(autor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Autores.AnyAsync(x => x.Id == id); //verifica que el id que pasamos sea igual al que ya existe
            if (!existe)
            {
                return NotFound("El id no existe");
            }

            dbContext.Remove(new Autor() { Id = id });//instanciamos autor
            await dbContext.SaveChangesAsync();
            return Ok("Se elimino el registro");    
        }

    }
}
