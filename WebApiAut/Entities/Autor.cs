using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApiAut.Validations;

namespace WebApiAut.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} no debe tener mas de {1} caracteres")]
        [Mayuscula]
        public string Nombre { get; set; }
        public List<AutorLibro> AutoresLibros { get; set; }//desde autor puedo acceder a libros

        // public List<Libro> Libros { get; set; } cargar libros

    }
}
