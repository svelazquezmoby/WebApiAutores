using AutoMapper;
using System.Collections.Generic;
using WebApiAut.Dtos;
using WebApiAut.Entities;

namespace WebApiAut.Utilities
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AutorCreacionDTO, Autor>(); //Post
            CreateMap<Autor, AutorDTO>(); //GEt transforma el listado de autores en listado dto
            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(libro => libro.AutoresLibros, opciones => opciones.MapFrom(MapAutoresLibros)); //Post

            CreateMap<Libro, LibroDTO>(); //GEt transforma el listado de libros en listado dto
            CreateMap<ComentarioCreacionDTO, Comentario>();//Post
            CreateMap<Comentario, ComentarioDTO>();//get
        }

        private List<AutorLibro> MapAutoresLibros(LibroCreacionDTO libroCreacionDTO, Libro libro)
        {
            var resultado = new List<AutorLibro>();
            if (libroCreacionDTO.AutoresIds == null) { return resultado; }
            foreach(var autorId in libroCreacionDTO.AutoresIds)
            {
                resultado.Add(new AutorLibro() { AutorId = autorId });
            }
            return resultado;
        }
    }
}
