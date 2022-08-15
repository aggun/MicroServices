using AutoMapper;
using CourseServicesCatalog.Dtos;
using CourseServicesCatalog.Models;

namespace CourseServicesCatalog.Mapping
{
    public class MapService : Profile
    {
        public MapService ()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }

    }
}
