using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with requests
    /// </summary>
    public static class RequestMappers
    {
        public static RequestDTO ToDTO(this Request model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Request, RequestDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("ClientName", opt => opt.MapFrom(x => x.ClientName))
                .ForMember("BookName", opt => opt.MapFrom(x => x.BookName))
                .ForMember("ClientProfileId", opt => opt.MapFrom(x => x.ClientProfileId))
                .ForMember("BookId", opt => opt.MapFrom(x => x.BookId));
            })
                .CreateMapper()
                .Map<Request, RequestDTO>(model);
        }
        public static IEnumerable<RequestDTO> ToDTO(this IEnumerable<Request> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
