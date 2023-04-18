using AutoMapper;
using Ecommerce.Application.Common.Dtos;
using Ecommerce.Application.Movie.Dtos;
using Ecommerce.Application.Movie.Queries.Get;
using Ecommerce.Domain.MovieAggregate.Enums;

namespace Ecommerce.Application.Movie.Queries.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Ecommerce.Domain.MovieAggregate.Movie, GetMoviesOutput>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
               .ForMember(dest => dest.MovieName, opt => opt.MapFrom(s => s.MovieName))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Description))
               .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => s.StartDate))
               .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => s.EndDate))
               .ForMember(dest => dest.MovieStatusId, opt => opt.MapFrom(s => s.MovieStatusId))
               .ForMember(dest => dest.MovieCategoryId, opt => opt.MapFrom(s => s.MovieCategoryId))
               .ForMember(dest => dest.MovieCategory, opt => opt.MapFrom(s => s.MovieCategory))
               .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(s => s.CinemaId))
               .ForMember(dest => dest.Cinema, opt => opt.MapFrom(s => s.Cinema)).ReverseMap();

            CreateMap<Ecommerce.Domain.MovieAggregate.Entity.MovieCategory, LookupDto<MovieCategoryEnum>>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.NameEn.Value));

            CreateMap<Ecommerce.Domain.MovieAggregate.Entity.MovieStatus, LookupDto<MovieStatusEnum>>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.NameEn.Value));

            CreateMap<Ecommerce.Domain.MovieAggregate.Entity.Cinema, CinemaDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Description));
        }
    }
}
