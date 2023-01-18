using System.ComponentModel.DataAnnotations;
using WebApiAut.Validations;

namespace WebApiAut.Dtos
{
    public class AutorCreacionDTO
    {   //post
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} no debe tener mas de {1} caracteres")]
        [Mayuscula]
        public string Nombre { get; set; }
    }
}
