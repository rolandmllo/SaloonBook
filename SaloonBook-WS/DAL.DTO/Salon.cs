using Domain.Contracts.Base;

namespace DAL.DTO;

public class Salon : IDomainEntityId
{
    public Guid Id { get; set; }
    public string SalonName { get; set; } = default!;
    
}