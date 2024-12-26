using AutoMapper;
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
        }

    }
}
