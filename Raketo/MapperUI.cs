using AutoMapper;
using Raketo.DAL.Entities;
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

            
        }

    }
}
