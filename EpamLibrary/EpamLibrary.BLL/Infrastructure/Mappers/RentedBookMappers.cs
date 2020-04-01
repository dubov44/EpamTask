using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with rented books
    /// </summary>
    public static class RentedBookMappers
    {
        public static RentedBookDTO ToDTO(this RentedBook model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentedBook, RentedBookDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookId", opt => opt.MapFrom(x => x.BookId))
                .ForMember("RentDate", opt => opt.MapFrom(x => x.RentDate))
                .ForMember("ReturnDate", opt => opt.MapFrom(x => x.ReturnDate))
                .ForMember("Penalty", opt => opt.MapFrom(x => x.Penalty))
                .ForMember("IsExpired", opt => opt.MapFrom(x => x.IsExpired))
                .ForMember("ReadingRoom", opt => opt.MapFrom(x => x.ReadingRoom));
            })
                .CreateMapper()
                .Map<RentedBook, RentedBookDTO>(model);
        }
        public static IEnumerable<RentedBookDTO> ToDTO(this IEnumerable<RentedBook> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
