using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Commands.Articles;

public record CreateArticleCommand(ArticleDto ArticleDto) : IRequest<ArticleDto>;

public class CreateArticleHandler : IRequestHandler<CreateArticleCommand, ArticleDto>
{
    private readonly IMapper _mapper;

    public CreateArticleHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<ArticleDto> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var category = new Category();
        if (request.ArticleDto.Category.Name != "")
        {
            category = await DB.Fluent<Category>()
                .Match(category => category.Name == request.ArticleDto.Category.Name)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        var article = new Article();
        article.Brand = request.ArticleDto.Brand;
        article.Model = request.ArticleDto.Model;
        article.Price = (double) request.ArticleDto.Price;
        article.Description = request.ArticleDto.Description;
        if (request.ArticleDto.Category.ID != "")
        {
            article.Category = category.ID != null ? category : null;
        }

        await article.SaveAsync(cancellation: cancellationToken);

        return new ArticleDto(article.ID,
            article.Brand,
            article.Model,
            article.Price,
            article.Description,
            category.ID != null
                ? _mapper.Map<CategoryDto>(
                    await article.Category.ToEntityAsync(cancellation: cancellationToken))
                : null
        );
    }
}