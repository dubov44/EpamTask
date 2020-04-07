using AutoMapper;
using EpamLibrary.BLL.DTO;
using EpamLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EpamLibrary.BLL.Infrastructure.Mappers
{
    /// <summary>
    /// to interact with books
    /// </summary>
    public static class BookMappers
    {
        public static BookDTO ToDTO(this Book model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("ImagePath", opt => opt.MapFrom(x => x.ImagePath))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors.Select(sel => StringChanger.CapitalizeAllWords(sel.Name)).ToList()))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres.Select(sel => StringChanger.CapitalizeAllWords(sel.Name)).ToList()))
                .ForMember("Publisher", opt => opt.MapFrom(x => StringChanger.CapitalizeAllWords(x.Publisher.Name)));
            })
                .CreateMapper()
                .Map<Book, BookDTO>(model);
        }
        public static IEnumerable<BookDTO> ToDTO(this IEnumerable<Book> models)
        {
            return models.Select(x => x.ToDTO());
        }

        public static Genre ToGenre(this string model)
        {
            return new MapperConfiguration(cfg =>
            {
            cfg.CreateMap<string, Genre>().ForMember(t => t.Name, opt => opt.MapFrom(s => s.Trim().ToLower()));
            })
                .CreateMapper()
                .Map<string, Genre>(model);
        }
        public static IEnumerable<Genre> ToGenres(this IEnumerable<string> models)
        {
            return models.Select(x => x.ToGenre());
        }
        public static Author ToAuthor(this string model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, Author>().ForMember(t => t.Name, opt => opt.MapFrom(s => s.Trim().ToLower()));
            })
                .CreateMapper()
                .Map<string, Author>(model);
        }
        public static IEnumerable<Author> ToAuthors(this IEnumerable<string> models)
        {
            return models.Select(x => x.ToAuthor());
        }
        public static Publisher ToPublisher(this string model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<string, Publisher>().ForMember(t => t.Name, opt => opt.MapFrom(s => s.Trim().ToLower()));
            })
                .CreateMapper()
                .Map<string, Publisher>(model);
        }
        public static Book ToEntity(this BookDTO model)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, Book>()
                .ForMember("Id", opt => opt.MapFrom(x => x.Id))
                .ForMember("IsDeleted", opt => opt.MapFrom(x => x.IsDeleted))
                .ForMember("Name", opt => opt.MapFrom(x => x.Name))
                .ForMember("Quantity", opt => opt.MapFrom(x => x.Quantity))
                .ForMember("Discription", opt => opt.MapFrom(x => x.Discription))
                .ForMember("ImagePath", opt => opt.MapFrom(x => x.ImagePath))
                .ForMember("PublicationDate", opt => opt.MapFrom(x => x.PublicationDate))
                .ForMember("Authors", opt => opt.MapFrom(x => x.Authors.ToAuthors()))
                .ForMember("Genres", opt => opt.MapFrom(x => x.Genres.ToGenres()))
                .ForMember("Publisher", opt => opt.MapFrom(x => x.Publisher.ToPublisher()));
            })
                .CreateMapper()
                .Map<BookDTO, Book>(model);
        }
    }
}
