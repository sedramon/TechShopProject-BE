using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Queries.Articles;

public record GetOneQuery(string ArticleId) : IRequest<ArticleDto>;

public class GetOneHandler : IRequestHandler<GetOneQuery, ArticleDto>
{
    private readonly IMapper _mapper;

    public GetOneHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ArticleDto> Handle(GetOneQuery request, CancellationToken cancellationToken)
    {
        var article = await DB.Fluent<Article>()
            .Match(article => article.ID == request.ArticleId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var articleDto = new ArticleDto(
            article.ID,
            article.Brand,
            article.Model,
            article.Price,
            article.Description,
            _mapper.Map<CategoryDto>(await article.Category.ToEntityAsync(cancellation: cancellationToken)));

        return articleDto;
    }
}