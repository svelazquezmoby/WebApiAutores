using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApiAut.Validations;

namespace WebApiAut.Dtos
{
    public class LibroCreacionDTO
    {
       
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Mayuscula]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} no debe tener mas de {1} caracteres")]
        public string Titulo { get; set; }
        public List<int> AutoresIds { get; set; }

    }
}
