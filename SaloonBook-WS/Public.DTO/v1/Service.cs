using Domain.Base;

namespace Public.DTO.v1;

public class Service : DomainEntityId
{
    public string ServiceName { get; set; }  = default!;
    public string ServiceDescription { get; set; }  = default!;
    
    public double Duration { get; set; }
    public double Price { get; set; }
}