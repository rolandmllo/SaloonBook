namespace BLL.DTO;

public class AppointmentScheduleByEmployeeName
{
    public string SalonName { get; set; } = default!;
    public string EmployeeFirstName { get; set; } = default!;
    public string EmployeeLastName { get; set; } = default!;
    
    public DateOnly? Date = default!;
    public ICollection<Appointment> Appointments { get; set; } = default!;

}