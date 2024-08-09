using Domain.Base;

namespace App.Domain;

public class Category : DomainEntityId
{
    public string CategoryName { get; set; }  = default!;
    public string Description { get; set; }  = default!;

    public ICollection<Service>? Services { get; set; }
}