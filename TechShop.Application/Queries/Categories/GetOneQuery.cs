using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Queries.Categories;

public record GetOneQuery(string CategoryId) : IRequest<CategoryDto>;

public class GetOneHandler : IRequestHandler<GetOneQuery, CategoryDto>
{
    private readonly IMapper _mapper;

    public GetOneHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetOneQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<CategoryDto>(await DB.Fluent<Category>().Match(author => author.ID == request.CategoryId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken));
    }
}