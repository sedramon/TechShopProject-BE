using Amazon.Runtime.Internal;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Domain.Entities;

namespace TechShop.Application.Commands.Users;

public record DeleteUserCommand(string? UserId) : IRequest<Task>;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Task>
{
    public async Task<Task> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await DB.Fluent<User>().Match(user => user.ID == request.UserId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        await user.DeleteAsync(cancellation: cancellationToken);

        return Task.CompletedTask;
    }
}