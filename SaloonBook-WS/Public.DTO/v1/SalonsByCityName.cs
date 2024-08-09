using App.Domain;
using Domain.Base;
using Salon = BLL.DTO.Salon;

namespace Public.DTO.v1;

public class SalonsByCityNames : DomainEntityId
{
    public string City { get; set; } = default!;

    public ICollection<Salon>? Salons { get; set; }

}