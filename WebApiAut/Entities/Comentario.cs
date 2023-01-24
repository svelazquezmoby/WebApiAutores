using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAut.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        //[ForeignKey("LibroId")]
        public int LibroId { get; set; }

        public Libro  Libro { get; set; }    //entidad de navegacion
    }
}
