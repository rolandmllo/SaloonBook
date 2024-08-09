using Domain.Base;

namespace App.Domain;

public class City : DomainEntityId
{
    public string CityName { get; set; } = default!;
    
    public ICollection<Salon>? Salons { get; set; }

}