using App.Domain.Identity;
using Domain.Base;

namespace BLL.DTO;

public class EmployeeServices : DomainEntityId
{
    public Guid EmployeeId { get; set; }
    public AppUser? Employee { get; set; }
    
    public Guid ServiceId { get; set; } = default!;
    public App.Domain.Service Service { get; set; } = default!;

}