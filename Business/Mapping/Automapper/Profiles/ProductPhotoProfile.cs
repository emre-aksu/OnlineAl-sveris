using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace Business.Mapping.Automapper.Profiles
{
    public class ProductPhotoProfile:Profile
    {
        public ProductPhotoProfile()
        {
            CreateMap<ProductPhoto, ProductPhotoDto>();
        }
    }
}
