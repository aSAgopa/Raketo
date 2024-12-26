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
        }
    }
}
