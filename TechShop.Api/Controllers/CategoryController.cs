using Microsoft.AspNetCore.Mvc;
using TechShop.Application.Commands.Categories;
using TechShop.Application.Queries.Categories;

namespace TechShop.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ApplicationController
{
    [HttpPost("create")]
    public async Task<OkObjectResult> CreateCategory(CreateCategoryCommand command) => Ok(await Mediator.Send(command));
    
    [HttpPut("update")]
    public async Task<OkObjectResult> UpdateCategory(CreateCategoryCommand command) => Ok(await Mediator.Send(command));
    
    [HttpDelete("delete")]
    public async Task<OkObjectResult> DeleteCategory(string categoryId) =>
        Ok(await Mediator.Send(new DeleteCategoryCommand(categoryId)));

    [HttpGet("get/all")]
    public async Task<OkObjectResult> GetAll() => Ok(await Mediator.Send(new GetAllQuery()));
    
    [HttpGet("get/one")]
    public async Task<OkObjectResult> GetOne(string categoryId) => Ok(await Mediator.Send(new GetOneQuery(categoryId)));
}