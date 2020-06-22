using AutoMapper;
using StoreHive.API.Dtos;
using StoreHive.API.Models;

namespace StoreHive.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Store, StoreForProductDto>();
        }
    }
}