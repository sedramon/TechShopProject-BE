using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Queries.Articles;

public record GetAllQuery : IRequest<List<ArticleDto>>;

public class GetAllHandler : IRequestHandler<GetAllQuery, List<ArticleDto>>
{
    private readonly IMapper _mapper;

    public GetAllHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<ArticleDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var articleEntity = await DB.Fluent<Article>()
            .ToListAsync(cancellationToken: cancellationToken);

        var articles = new List<ArticleDto>();

        foreach (Article article in articleEntity)
        {
            var articleDto = new ArticleDto(article.ID,
                article.Brand,
                article.Model,
                article.Price,
                article.Description,
                article.Category != null
                    ? _mapper.Map<CategoryDto>(await article.Category.ToEntityAsync(cancellation: cancellationToken))
                    : null
            );
            articles.Add(articleDto);
        }

        return articles;

    }
}