using AutoMapper;
using Library.Core.DTOs;
using Library.Core.Entities;

namespace Library.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<Editorial, EditorialDto>();
            CreateMap<EditorialDto, Editorial>();

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
        }
    }
}
