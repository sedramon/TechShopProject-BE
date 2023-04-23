using AutoMapper;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;
using MediatR;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Commands.Categories;

public record CreateCategoryCommand(CategoryDto CategoryDto) : IRequest<CategoryDto>;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IMapper _mapper;
     
    public CreateCategoryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
     
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.CategoryDto);
     
        await category.SaveAsync(cancellation: cancellationToken);
     
        return _mapper.Map<CategoryDto>(category);
    }
}