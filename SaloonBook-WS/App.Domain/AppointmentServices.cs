using Domain.Base;

namespace App.Domain;

public class AppointmentServices : DomainEntityId
{
    public Appointment? Appointment { get; set; }
    public Guid? AppointmentId { get; set; }

    public Guid ServiceId { get; set; } = default!;
    public Service Service { get; set; } = default!;
}