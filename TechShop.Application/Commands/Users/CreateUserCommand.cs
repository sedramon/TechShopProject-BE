using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Commands.Users;

public record CreateUserCommand(UserDto UserDto) : IRequest<UserDto>;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IMapper _mapper;

    public CreateUserHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.UserDto);
        await user.SaveAsync(cancellation: cancellationToken);
        return _mapper.Map<UserDto>(user);
    }
}