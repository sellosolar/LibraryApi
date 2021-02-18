using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;

namespace Library.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.AuthorName, opt => opt.MapFrom(a => a.Author.FullName))
                .ForMember(b => b.EditorialName, opt => opt.MapFrom(a => a.Editorial.Name));

            CreateMap<BookDto, Book>();

            CreateMap<Editorial, EditorialDto>();
            CreateMap<EditorialDto, Editorial>();

            CreateMap<Author, AuthorDto>()
                .ForMember(a => a.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()));
            CreateMap<AuthorDto, Author>();
        }
    }
}
