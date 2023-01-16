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

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await dbContext.Autores.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            dbContext.Add(autor);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
