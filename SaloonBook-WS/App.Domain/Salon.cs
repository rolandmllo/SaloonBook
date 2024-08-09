using Domain.Base;

namespace App.Domain;

public class Salon : DomainEntityId
{
    
    public string SalonName { get; set; }  = default!;
    
    public string SalonAddress { get; set; }  = default!;

    public City City { get; set; } = default!;
    
    public string SalonPhone { get; set; }  = default!;
    
    public string SalonEmail { get; set; }  = default!;

    public ICollection<Appointment>? Appointments { get; set; }
    
}