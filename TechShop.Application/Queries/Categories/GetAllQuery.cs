using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Queries.Categories;

public record GetAllQuery : IRequest<List<CategoryDto>>;

public class GetAllHandler : IRequestHandler<GetAllQuery, List<CategoryDto>>
{
    private readonly IMapper _mapper;

    public GetAllHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<CategoryDto>>(await DB.Fluent<Category>().ToListAsync(cancellationToken: cancellationToken));
    }
}