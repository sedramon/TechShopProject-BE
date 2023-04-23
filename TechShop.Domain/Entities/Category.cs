using MongoDB.Entities;

namespace TechShop.Domain.Entities;
[Collection("categories")]
public class Category : Entity, ICreatedOn, IModifiedOn
{
    [Field("name")] 
    public string Name { get; set; }

    [Field("created_on")] 
    public DateTime CreatedOn { get; set; }
    
    [Field("modified_on")] 
    public DateTime ModifiedOn { get; set; }
}