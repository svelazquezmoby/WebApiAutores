using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApiAut.Validations;

namespace WebApiAut.Dtos
{
    public class LibroDTO
    {
        public int Id { get; set; }     
        public string Titulo { get; set; }

        public List<ComentarioDTO> Comentarios { get; set; }
    }
}
