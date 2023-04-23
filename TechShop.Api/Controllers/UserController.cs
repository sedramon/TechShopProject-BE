using Microsoft.AspNetCore.Mvc;
using TechShop.Application.Commands.Users;
using TechShop.Application.Common.Dtos;
using TechShop.Application.Queries.Users;

namespace TechShop.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ApplicationController
{
    [HttpPost("create")]
    public async Task<OkObjectResult> CreateUser(UserDto dto) => Ok(await Mediator.Send(new CreateUserCommand(dto)));
    
    [HttpPut("update")]
    public async Task<OkObjectResult> UpdateUser(UserDto dto) => Ok(await Mediator.Send(new CreateUserCommand(dto)));
    
    [HttpDelete("delete")]
    public async Task<OkObjectResult> DeleteUser(string userId) =>
        Ok(await Mediator.Send(new DeleteUserCommand(userId)));
    
    [HttpGet("get/all")]
    public async Task<OkObjectResult> GetAll() => Ok(await Mediator.Send(new GetAllQuery()));
    
    [HttpGet("get/one")]
    public async Task<OkObjectResult> GetOne(string userId) => Ok(await Mediator.Send(new GetOneQuery(userId)));
}