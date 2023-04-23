using Microsoft.AspNetCore.Mvc;
using TechShop.Application.Commands.Articles;
using TechShop.Application.Common.Dtos;
using TechShop.Application.Queries.Articles;

namespace TechShop.Controllers;

[ApiController]
[Route("api/article")]
public class ArticleController : ApplicationController
{
    [HttpPost("create")]
    public async Task<OkObjectResult> CreateArticle(ArticleDto dto) => Ok(await Mediator.Send(new CreateArticleCommand(dto)));
    
    [HttpPut("update")]
    public async Task<OkObjectResult> UpdateArticle(UpdateArticleCommand command) => Ok(await Mediator.Send(command));

    [HttpDelete("delete")]
    public async Task<OkObjectResult> DeleteArticle(string articleId) =>
        Ok(await Mediator.Send(new DeleteArticleCommand(articleId)));
    
    [HttpGet("get/one")]
    public async Task<OkObjectResult> GetOne(string articleId) => Ok(await Mediator.Send(new GetOneQuery(articleId)));
    
    [HttpGet("get/all")]
    public async Task<OkObjectResult> GetAll() => Ok(await Mediator.Send(new GetAllQuery()));
}