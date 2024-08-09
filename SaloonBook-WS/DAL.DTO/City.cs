using Domain.Base;

namespace DAL.DTO;

public class City : DomainEntityId
{
    public string CityName { get; set; } = default!;
    
    public ICollection<Salon>? Salons { get; set; }

}