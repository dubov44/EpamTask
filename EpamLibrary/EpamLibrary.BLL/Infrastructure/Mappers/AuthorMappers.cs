using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
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
