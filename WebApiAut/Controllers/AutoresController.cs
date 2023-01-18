using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAut.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApiAut.Filters;
using WebApiAut.Dtos;
using AutoMapper;
using System.Linq;

namespace WebApiAut.Controllers
{
    [ApiController]
    [Route("api/autores")]  
    
    public class AutoresController : ControllerBase
    {
         private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext dbContext, IMapper mapper)
         {
             this.dbContext = dbContext;
            this.mapper = mapper;
        }

         [HttpGet]//atributos
         //[Authorize]
         [ServiceFilter(typeof(FiltroAccion))]
         public async Task<List<AutorDTO>> Get()
         {
             var autores = await dbContext.Autores.ToListAsync();
             return mapper.Map<List<AutorDTO>>(autores);//le pasamos los autores

         }

         [HttpGet("primero")]
         public async Task<ActionResult<Autor>> PrimerAutor()
         {
             return await dbContext.Autores.FirstOrDefaultAsync();
         }

         [HttpGet("{id:int}")]
         public async Task<ActionResult<AutorDTO>> Get(int id)
         {
             var autor =  await dbContext.Autores.FirstOrDefaultAsync(autorbd => autorbd.Id == id);//retorna null si no lo encuentra
             if (autor == null)
             {
                 return NotFound("el id no existe");
             }
             return mapper.Map<AutorDTO>(autor);
         }

         [HttpGet("{nombre}")]//busqueda por nombre
         public async Task<ActionResult<List<AutorDTO>>> Get([FromRoute] string nombre)
         {
             var autores = await dbContext.Autores.Where(autorbd => autorbd.Nombre.Contains(nombre)).ToListAsync();//retorna null si no lo encuentra
                             
             return mapper.Map<List<AutorDTO>>(autores);
         }

         [HttpPost]
         public async Task<ActionResult> Post([FromBody]AutorCreacionDTO autorCreacionDTO)
         {
             var existeIgualNombre= await dbContext.Autores.AnyAsync(x => x.Nombre == autorCreacionDTO.Nombre);
             if (existeIgualNombre)
             {
                 return BadRequest($"Ya existe el nombre {autorCreacionDTO.Nombre}");
             }
            //mapeo manual
            // var autor = new Autor() { Nombre = autorCreacionDTO.Nombre };
            //dbContext.Add(autor);
            //dbContext.Add(autorCreacionDTO); error no es una tabla valida
            var autor = mapper.Map<Autor>(autorCreacionDTO);
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
