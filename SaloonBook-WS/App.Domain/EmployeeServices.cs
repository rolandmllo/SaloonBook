using App.Domain.Identity;
using Domain.Base;

namespace App.Domain;

public class EmployeeServices : DomainEntityId
{
    public Guid EmployeeId { get; set; }
    public AppUser? Employee { get; set; }
    
    public Guid ServiceId { get; set; } = default!;
    public Service Service { get; set; } = default!;

}