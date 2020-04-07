using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with publishers
    /// </summary>
    public static class PublisherMappers
    {
        public static PublisherDTO ToDTO(this Publisher model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Publisher, PublisherDTO>()
                .ForMember("Name", opt => opt.MapFrom(x => StringChanger.CapitalizeAllWords(x.Name)))
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
