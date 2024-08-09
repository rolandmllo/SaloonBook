using Domain.Base;
using Domain.Contracts.Base;

namespace Public.DTO.v1;

public class Category : DomainEntityId
{
    public string CategoryName { get; set; }  = default!;
    public string Description { get; set; }  = default!;
}