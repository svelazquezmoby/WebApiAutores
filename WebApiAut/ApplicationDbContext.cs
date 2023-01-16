using Microsoft.EntityFrameworkCore;
using WebApiAut.Entities;

namespace WebApiAut
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)//constructor
        {
            
        }
        public DbSet<Autor> Autores { get; set; }
    }
}
