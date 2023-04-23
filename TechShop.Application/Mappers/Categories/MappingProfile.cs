using AutoMapper;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Mappers.Categories;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<Many<Category>, List<CategoryDto>>().ConstructUsing(x => ManyToList(x));
    }

    private static List<CategoryDto> ManyToList(Many<Category> manyCategory)
    {
        return manyCategory.Select(category =>
            new CategoryDto(category.ID, category.Name)).ToList();
    }
}