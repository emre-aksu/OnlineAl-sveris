using AutoMapper;
using Model.Dtos;
using Model.Entities;
using Model.JsonResponseObjects;

namespace Business.Mapping.Automapper.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductJsonResponseObject>();
        }
    }
}
