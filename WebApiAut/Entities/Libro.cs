
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApiAut.Validations;

namespace WebApiAut.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Mayuscula]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} no debe tener mas de {1} caracteres")]
        public string Titulo { get; set; }
        public List<Comentario> Comentarios { get; set; } //join 

        //public int AutorId { get; set; }

        //public Autor Autor { get; set; }
    }
}
