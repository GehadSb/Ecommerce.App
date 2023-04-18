using AutoMapper;
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

        }
    }
}
