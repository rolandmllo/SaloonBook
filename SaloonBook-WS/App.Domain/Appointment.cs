using App.Domain.Identity;
using Domain.Base;

namespace App.Domain;

public class Appointment : DomainEntityId
{
    public Guid ClientId { get; set; }
    
    public AppUser Client { get; set; } = default!;
    
    public Guid  EmployeeId { get; set; }
    public AppUser Employee { get; set; }  = default!;

    public ICollection<AppointmentServices> AppointmentServices { get; set; }  = default!;

    public DateTime ReservationFrom { get; set; }
    public DateTime ReservationUntil { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public Guid SalonId { get; set; }
    public Salon Salon { get; set; }  = default!;

    public bool Done { get; set; }

    public string? Comment { get; set; } 
    
    public Guid CategoryId { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
    
}