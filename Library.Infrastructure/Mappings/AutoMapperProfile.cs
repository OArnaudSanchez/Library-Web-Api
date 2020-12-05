using AutoMapper;
using Library.Core;
using Library.Core.DTos;

namespace Library.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
        }
    }
}