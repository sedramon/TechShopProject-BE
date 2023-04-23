namespace TechShop.Application.Common.Dtos;

public record ArticleDto(
    string? ID,
    string? Brand, 
    string? Model, 
    double? Price, 
    string? Description, 
    CategoryDto? Category);