using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Domain.Entities;
using IRequest = Amazon.Runtime.Internal.IRequest;

namespace TechShop.Application.Commands.Categories;

public record DeleteCategoryCommand(string CategoryId) : IRequest<Task>;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Task>
{
    public async Task<Task> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await DB.Fluent<Category>().Match(category => category.ID == request.CategoryId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        await category.DeleteAsync(cancellation: cancellationToken);

        return Task.CompletedTask;
    }
}