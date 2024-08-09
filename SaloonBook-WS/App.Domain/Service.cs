using App.Domain.Identity;
using Domain.Base;

namespace App.Domain;

public class Service : DomainEntityId
{
    public string ServiceName { get; set; }  = default!;
    public string ServiceDescription { get; set; }  = default!;
    
    public double Duration { get; set; }
    public double Price { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }  = default!;

    public ICollection<AppointmentServices>? AppointmentServices { get; set; }
    
    public ICollection<EmployeeServices>? EmployeeServices { get; set; }


}