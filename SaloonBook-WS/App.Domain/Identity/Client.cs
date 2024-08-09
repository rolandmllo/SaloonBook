namespace App.Domain.Identity;

public class Client : AppUser
{
    public EUserRole AppRole { get; } = EUserRole.Client;
    
    public ICollection<Appointment>? Appointments { get; set; }


    
}