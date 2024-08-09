using Domain.Base;

namespace BLL.DTO;

public class SalonsByCityName : DomainEntityId
{
    public string City { get; set; } = default!;

    public ICollection<Salon>? Salons { get; set; }

}