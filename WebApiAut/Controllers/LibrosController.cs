using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApiAut.Dtos;
using WebApiAut.Entities;

namespace WebApiAut.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
       private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var libro =  await dbContext.Libros.FirstOrDefaultAsync(x => x.Id == id);//query 
            return mapper.Map<LibroDTO>(libro);
        }
        [HttpPost]
        public async Task<ActionResult> Post(LibroCreacionDTO libroCreacionDTO)
        {
            /*var existe = await dbContext.Autores.AnyAsync(x => x.Id == libro.AutorId); //verifica que el id que pasamos sea igual al que ya existe
             if(!existe)
             {
                 return BadRequest("No existe autor con esa id");
             }*/
            var libro = mapper.Map<Libro>(libroCreacionDTO);

            dbContext.Add(libro);
            await dbContext.SaveChangesAsync();
            return Ok("Libro Agregado");
        }



    }
}
