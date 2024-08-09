using App.Domain;
using Domain.Base;

namespace BLL.DTO;

public class Category : DomainEntityId
{
    public string CategoryName { get; set; }  = default!;
    public string Description { get; set; }  = default!;

    public ICollection<Service>? Services { get; set; }
}