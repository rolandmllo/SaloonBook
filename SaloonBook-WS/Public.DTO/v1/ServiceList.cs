using Domain.Base;
using Domain.Contracts.Base;

namespace Public.DTO.v1;

public class ServiceList : DomainEntityId
{
    public string ServiceName { get; set; }  = default!;
}