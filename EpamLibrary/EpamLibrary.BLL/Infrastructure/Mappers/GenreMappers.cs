using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with genres
    /// </summary>
    public static class GenreMappers
    {
        public static GenreDTO ToDTO(this Genre model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreDTO>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.Books.Count));
            })
                .CreateMapper()
                .Map<Genre, GenreDTO>(model);
        }
        public static IEnumerable<GenreDTO> ToDTO(this IEnumerable<Genre> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
