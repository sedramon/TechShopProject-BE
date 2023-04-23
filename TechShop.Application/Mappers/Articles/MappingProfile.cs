using AutoMapper;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Mappers.Articles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Article, ArticleDto>().ReverseMap();
    }
}