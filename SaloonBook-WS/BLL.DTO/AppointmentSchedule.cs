using Domain.Base;

namespace BLL.DTO;

public class AppointmentSchedule : DomainEntityId
{
    public string SalonName { get; set; } = default!;
    public string EmployeeName { get; set; } = default!;
    public DateOnly Date = default!;
    public ICollection<Appointment> Appointments { get; set; } = default!;

}