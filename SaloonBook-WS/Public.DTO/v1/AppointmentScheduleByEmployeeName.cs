namespace Public.DTO.v1;

public class AppointmentScheduleByEmployeeName
{
    public string SalonName { get; set; } = default!;
    public string EmployeeFirstName { get; set; } = default!;
    public string EmployeeLastName { get; set; } = default!;
    
    public DateOnly? Date = default!;
    public ICollection<AppointmentBooking> Appointments { get; set; } = default!;

}