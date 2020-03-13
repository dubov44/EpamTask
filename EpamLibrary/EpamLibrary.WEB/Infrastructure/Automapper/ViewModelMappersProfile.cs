using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.AuthorVM;
using EpamLibrary.WEB.Models.BookVM;
using EpamLibrary.WEB.Models.PublisherVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Infrastructure.Automapper
{
    public static class ViewModelMappersProfile
    {
        public static BookEditModel ToEditModel(this BookDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookEditModel>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate.Date))
                .ForMember("Authors", opt => opt.MapFrom(x => string.Join(",", x.Authors)))
                .ForMember("Genres", opt => opt.MapFrom(x => string.Join(",", x.Genres)))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher));
            })
                .CreateMapper()
                .Map<BookDTO, BookEditModel>(model);
        }
        public static BookDTO ToDTO(this BookEditModel model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookEditModel, BookDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors.Split(',').ToList()))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres.Split(',').ToList()))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher));
            })
                .CreateMapper()
                .Map<BookEditModel, BookDTO>(model);
        }
        public static BookViewModel ToDisplayVM(this BookDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, BookViewModel>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher));
            })
                .CreateMapper()
                .Map<BookDTO, BookViewModel>(model);
        }
        public static IEnumerable<BookViewModel> ToDisplayVM(this IEnumerable<BookDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }

        public static AuthorViewModel ToDisplayVM(this AuthorDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTO, AuthorViewModel>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.BookQuantity));
            })
                .CreateMapper()
                .Map<AuthorDTO, AuthorViewModel>(model);
        }
        public static IEnumerable<AuthorViewModel> ToDisplayVM(this IEnumerable<AuthorDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }

        public static PublisherViewModel ToDisplayVM(this PublisherDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PublisherDTO, PublisherViewModel>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.BookQuantity));
            })
                .CreateMapper()
                .Map<PublisherDTO, PublisherViewModel>(model);
        }
        public static IEnumerable<PublisherViewModel> ToDisplayVM(this IEnumerable<PublisherDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
    }
}