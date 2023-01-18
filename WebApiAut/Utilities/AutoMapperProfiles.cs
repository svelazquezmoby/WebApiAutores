using AutoMapper;
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
            CreateMap<LibroCreacionDTO, Libro>(); //Post
            CreateMap<Libro, LibroDTO>(); //GEt transforma el listado de libros en listado dto

        }
    }
}
