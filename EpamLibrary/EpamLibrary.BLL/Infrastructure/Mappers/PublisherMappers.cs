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
    public static class PublisherMappers
    {
        public static PublisherDTO ToDTO(this Publisher model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherDTO>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.Books.Count));
            })
                .CreateMapper()
                .Map<Publisher, PublisherDTO>(model);
        }
        public static IEnumerable<PublisherDTO> ToDTO(this IEnumerable<Publisher> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
