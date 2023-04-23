using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Domain.Entities;

namespace TechShop.Application.Commands.Articles;

public record DeleteArticleCommand(string ArticleId) : IRequest<Task>;

public class DeleteArticleHandler : IRequestHandler<DeleteArticleCommand, Task>
{
    public async Task<Task> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await DB.Fluent<Article>().Match(article => article.ID == request.ArticleId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        await article.DeleteAsync(cancellation: cancellationToken);

        return Task.CompletedTask;
    }
}