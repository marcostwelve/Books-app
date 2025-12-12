using AutoMapper;
using Books.Application.Books.Command.Create;
using Books.Application.Books.Command.Update;
using Books.Domain.Dtos.Create;
using Books.Domain.Dtos.Update;
using Books.Domain.Dtos.View;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, CreateBookCommand>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ReverseMap();

            CreateMap<Book, BookViewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<Book, CreateBookDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ReverseMap();

            CreateMap<Book, UpdateBookDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ReverseMap();

            CreateMap<Book, UpdateBookCommand>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                .ReverseMap();
        }
    }
}
