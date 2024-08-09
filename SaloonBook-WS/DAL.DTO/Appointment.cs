namespace DAL.DTO;

public class Appointment
{
    public Guid Id { get; set; }
    //public string SalonName { get; set; } = default!;
    public string EmployeeFirstName { get; set; } = default!;
    public string EmployeeLastName { get; set; } = default!;
    //public string ServiceName { get; set; } = default!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}