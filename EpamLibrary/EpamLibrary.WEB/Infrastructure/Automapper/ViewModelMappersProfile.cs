using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.BLL.Infrastructure;
using EpamLibrary.WEB.Models;
using EpamLibrary.WEB.Models.AuthorVM;
using EpamLibrary.WEB.Models.BookVM;
using EpamLibrary.WEB.Models.GenreVM;
using EpamLibrary.WEB.Models.PublisherVM;
using EpamLibrary.WEB.Models.RentedBookVM;
using EpamLibrary.WEB.Models.RequestVM;
using EpamLibrary.WEB.Models.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamLibrary.WEB.Infrastructure.Automapper
{
    public static class ViewModelMappersProfile
    {
        #region BookDTO -> BookEditModel
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
        #endregion

        #region BookEditModel -> BookDTO
        public static BookDTO ToDTO(this BookEditModel model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookEditModel, BookDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("ImagePath", opt => opt.MapFrom(x => x.ImagePath))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors.Split(',').ToList()))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres.Split(',').ToList()))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher));
            })
                .CreateMapper()
                .Map<BookEditModel, BookDTO>(model);
        }
        #endregion

        #region BookDTO -> BookViewModel
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
                .ForMember("ImagePath", opt => opt.MapFrom(x => x.ImagePath))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher));
            })
                .CreateMapper()
                .Map<BookDTO, BookViewModel>(model);
        }
        #endregion

        #region IEnumerable<BookDTO> -> IEnumerable<BookViewModel>
        public static IEnumerable<BookViewModel> ToDisplayVM(this IEnumerable<BookDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region AuthorDTO -> AuthorViewModel
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
        #endregion

        #region IEnumerable<AuthorDTO> -> IEnumerable<AuthorViewModel>
        public static IEnumerable<AuthorViewModel> ToDisplayVM(this IEnumerable<AuthorDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region PublisherDTO -> PublisherViewModel
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
        #endregion

        #region IEnumerable<PublisherDTO> -> IEnumerable<PublisherViewModel>
        public static IEnumerable<PublisherViewModel> ToDisplayVM(this IEnumerable<PublisherDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region GenreDTO -> GenreViewModel
        public static GenreViewModel ToDisplayVM(this GenreDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GenreDTO, GenreViewModel>()
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookQuantity", opt => opt.MapFrom(x => x.BookQuantity));
            })
                .CreateMapper()
                .Map<GenreDTO, GenreViewModel>(model);
        }
        #endregion

        #region IEnumerable<GenreDTO> -> IEnumerable<GenreViewModel>
        public static IEnumerable<GenreViewModel> ToDisplayVM(this IEnumerable<GenreDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region RentedBookDTO -> RentedBookViewModel
        public static RentedBookViewModel ToDisplayVM(this RentedBookDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentedBookDTO, RentedBookViewModel>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("BookId", opt => opt.MapFrom(x => x.BookId))
                .ForMember("RentDate", opt => opt.MapFrom(x => x.RentDate))
                .ForMember("ReturnDate", opt => opt.MapFrom(x => x.ReturnDate))
                .ForMember("Penalty", opt => opt.MapFrom(x => x.Penalty))
                .ForMember("Debt", opt => opt.MapFrom(x => x.Penalty * Int32.Parse((DateTime.Now - x.ReturnDate).Days.ToString())))
                .ForMember("IsExpired", opt => opt.MapFrom(x => x.IsExpired));
            })
                .CreateMapper()
                .Map<RentedBookDTO, RentedBookViewModel>(model);
        }
        #endregion

        #region IEnumerable<RentedBookDTO> -> IEnumerable<RentedBookViewModel>
        public static IEnumerable<RentedBookViewModel> ToDisplayVM(this IEnumerable<RentedBookDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region RequestDTO -> RequestViewModel
        public static RequestViewModel ToDisplayVM(this RequestDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestDTO, RequestViewModel>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("ClientName", opt => opt.MapFrom(x => x.ClientName))
                .ForMember("BookName", opt => opt.MapFrom(x => x.BookName))
                .ForMember("ClientProfileId", opt => opt.MapFrom(x => x.ClientProfileId))
                .ForMember("BookId", opt => opt.MapFrom(x => x.BookId));
            })
                .CreateMapper()
                .Map<RequestDTO, RequestViewModel>(model);
        }
        #endregion

        #region IEnumerable<RequestDTO> -> IEnumerable<RequestViewModel>
        public static IEnumerable<RequestViewModel> ToDisplayVM(this IEnumerable<RequestDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region UserDTO -> UserViewModel
        public static UserViewModel ToDisplayVM(this UserDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserViewModel>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("Email", opt => opt.MapFrom(x => x.Email))
                .ForMember("UserName", opt => opt.MapFrom(x => x.UserName))
                .ForMember("Role", opt => opt.MapFrom(x => x.Role));
            })
                .CreateMapper()
                .Map<UserDTO, UserViewModel>(model);
        }
        #endregion

        #region IEnumerable<UserDTO> -> IEnumerable<UserViewModel>
        public static IEnumerable<UserViewModel> ToDisplayVM(this IEnumerable<UserDTO> models)
        {
            return models.Select(x => x.ToDisplayVM());
        }
        #endregion

        #region OperationDetails -> OperationDetailsViewModel
        public static OperationDetailsViewModel ToDisplayVM(this OperationDetails model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OperationDetails, OperationDetailsViewModel>()
                .ForMember("Succedeed", opt => opt.MapFrom(x => x.Succedeed))
                .ForMember("Message", opt => opt.MapFrom(x => x.Message));
            })
                .CreateMapper()
                .Map<OperationDetails, OperationDetailsViewModel>(model);
        }
        #endregion
    }
}