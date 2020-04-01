using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with identity framework users
    /// </summary>
    public static class UserMappers
    {
        public static UserDTO ToDTO(this ApplicationUser model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("Email", opt => opt.MapFrom(x => x.Email))
                .ForMember("UserName", opt => opt.MapFrom(x => x.UserName));
            })
                .CreateMapper()
                .Map<ApplicationUser, UserDTO>(model);
        }
        public static IEnumerable<UserDTO> ToDTO(this IEnumerable<ApplicationUser> models)
        {
            return models.Select(x => x.ToDTO());
        }
    }
}
