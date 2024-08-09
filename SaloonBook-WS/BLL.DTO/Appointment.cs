using Domain.Base;

namespace BLL.DTO;

public class Appointment : DomainEntityId
{
    public string? EmployeeFirstName { get; set; } = default!;
    public string? EmployeeLastName { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public Guid EmployeeId { get; set; } = default!;
    public Guid ClientId { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
    public Guid SalonId { get; set; } = default!;

    public override string ToString()
    {
        return "Id: " + Id.ToString();
    }
}