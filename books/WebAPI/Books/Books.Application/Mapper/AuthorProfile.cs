using AutoMapper;
using Books.Domain.Dtos.Create;
using Books.Domain.Dtos.View;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Mapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Domain.Entities.Author, CreateAuthorDto>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ReverseMap();

            CreateMap<Domain.Entities.Author, AuthorViewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
