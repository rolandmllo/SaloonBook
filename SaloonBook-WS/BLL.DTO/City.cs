using Domain.Base;

namespace BLL.DTO;

public class City : DomainEntityId
{
    public string CityName { get; set; } = default!;
    
    public ICollection<App.Domain.Salon>? Salons { get; set; }

}