using App.Domain.Identity;
using Domain.Base;

namespace BLL.DTO;

public class EmployeeSchedule : DomainEntityId
{
    public Guid EmployeeId { get; set; }
    public AppUser Employee { get; set; }  = default!;

    public DateTime From { get; set; }
    public DateTime Until { get; set; }

    public Guid SalonId { get; set; }
    public Salon Salon { get; set; }  = default!;
}