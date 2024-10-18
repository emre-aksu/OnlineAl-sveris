using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace Business.Mapping.Automapper.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();
            CreateMap<CategoryEditDto, Category>().ForMember(dest=> dest.Id,opt=>opt.MapFrom(src=>src.CategoryId));
        }
    }
}
