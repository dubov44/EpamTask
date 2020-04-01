using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with authors
    /// </summary>
    public static class AuthorMappers
    {
        public static AuthorDTO ToDTO(this Author model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.Books.Count));
            })
                .CreateMapper()
                .Map<Author, AuthorDTO>(model);
        }
        public static IEnumerable<AuthorDTO> ToDTO(this IEnumerable<Author> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
