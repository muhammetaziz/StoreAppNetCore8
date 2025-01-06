using AutoMapper;

using StoreApp.Data.Concrete;

namespace StoreApp.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>();

        }
    }
}
