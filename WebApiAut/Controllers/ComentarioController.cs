using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAut.Dtos;
using WebApiAut.Entities;

namespace WebApiAut.Controllers
{
    [ApiController]
    [Route("api/comentarios")]//api/carrie/1/comentario
    public class ComentarioController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ComentarioController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComentarioDTO>>> Get(int libroid)
        {
            var existeLibro = await dbContext.Libros.AnyAsync(librobd => librobd.Id == libroid);
            if (!existeLibro)
            {
                return NotFound("libro no existe");
            }
            var comentarios = await dbContext.Comentarios.Where(comentariodb => comentariodb.LibroId == libroid).ToListAsync();
            return  mapper.Map<List<ComentarioDTO>>(comentarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int libroid, ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var existeLibro = await dbContext.Libros.AnyAsync(librobd => librobd.Id == libroid);
            if(!existeLibro)
            {
                return NotFound("no existe");
            }

            var comentario = mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.LibroId = libroid;
            dbContext.Add(comentario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
