using AutoMapper;
using Raketo.Models;
using Raketo.Model;
using Raketo.ViewModel;


namespace Raketo
{
    public class MapperUI : Profile
    {
        public MapperUI()
        {
            CreateMap<ProductViewModel, ProductDto>();
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>();
            CreateMap<OrderViewModel, OrderDto>();
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<CustomerBankInfo, CustomerBankInfoDto>();
            CreateMap<CustomerBankInfoDto,CustomerBankInfo>();

        }

    }
}
