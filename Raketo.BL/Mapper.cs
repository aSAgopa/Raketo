using AutoMapper;
using Raketo.DAL.Entities;
using Raketo.Model;


namespace Raketo.BL
{

    public class MapperBL : Profile
    {
        public MapperBL()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>(); 
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
