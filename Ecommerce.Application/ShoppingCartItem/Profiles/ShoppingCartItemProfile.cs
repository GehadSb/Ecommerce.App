using AutoMapper;
using Ecommerce.Application.Order.Commands.Save;
using Ecommerce.Application.Order.Dtos;

namespace Ecommerce.Application.ShoppingCartItem.Profiles
{
    public class ShoppingCartItemProfile : Profile
    {
        public ShoppingCartItemProfile()
        {
            CreateMap<Ecommerce.Domain.ShoppingCartItemAggregate.ShoppingCartItem, ShoppingCartItemsDto>()
            //.ForMember(dest => dest.Movie, opt => opt.MapFrom(s => s.Movie))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(s => s.Amount))
            .ForMember(dest => dest.ShoppingCartId, opt => opt.MapFrom(s => s.ShoppingCartId)).ReverseMap();

            CreateMap<ShoppingCartItemInput, Domain.ShoppingCartItemAggregate.ShoppingCartItem>()
              .ForMember(dest => dest.Movie, opt => opt.MapFrom(s => s.Movie))
              .ForMember(dest => dest.Amount, opt => opt.MapFrom(s => s.Amount))
              .ForMember(dest => dest.ShoppingCartId, opt => opt.MapFrom(s => s.ShoppingCartId)).ReverseMap();

            CreateMap<MovieInput, Domain.MovieAggregate.Movie>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(dest => dest.MovieName, opt => opt.MapFrom(s => s.MovieName))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(s => s.Description))
              .ForMember(dest => dest.StartDate, opt => opt.MapFrom(s => s.StartDate))
              .ForMember(dest => dest.EndDate, opt => opt.MapFrom(s => s.EndDate))
              .ForMember(dest => dest.MovieStatusId, opt => opt.MapFrom(s => s.MovieStatusId))
              .ForMember(dest => dest.MovieCategoryId, opt => opt.MapFrom(s => s.MovieCategoryId))
              .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(s => s.CinemaId)).ReverseMap();
        }
    }
}
