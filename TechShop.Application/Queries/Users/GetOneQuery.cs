using Amazon.Runtime.Internal;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using TechShop.Application.Common.Dtos;
using TechShop.Domain.Entities;

namespace TechShop.Application.Queries.Users;

public record GetOneQuery(string UserId) : IRequest<UserDto>;

public class GetOneHandler : IRequestHandler<GetOneQuery, UserDto>
{
    private readonly IMapper _mapper;

    public GetOneHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<UserDto> Handle(GetOneQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserDto>(await DB.Fluent<User>().Match(user => user.ID == request.UserId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken));
    }
}