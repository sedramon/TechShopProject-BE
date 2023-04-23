using MongoDB.Entities;

namespace TechShop.Domain.Entities;

public class Article : Entity, ICreatedOn, IModifiedOn
{
    [Field("title")] 
    public string Brand { get; set; }

    [Field("summary")] 
    public string Model { get; set; }
    
    [Field("price")]
    public double Price { get; set; }
    
    [Field("description")]
    public string Description { get; set; }
    
    [Field("category_id")] 
    public One<Category> Category { get; set; }
    
    [Field("created_on")] 
    public DateTime CreatedOn { get; set; }

    [Field("modified_on")] 
    public DateTime ModifiedOn { get; set; }
}