namespace App.Domain.Identity;

public class Employee : AppUser
{
    public EUserRole AppRole { get; } = EUserRole.Employee;

    public ICollection<Schedule>? Schedule { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }

}