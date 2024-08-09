namespace DAL.DTO;

public class AppointmentScheduleByEmployee
{
    public Guid Id { get; set; }
    public string PlanName { get; set; } = default!;
    public int EventCount { get; set; }
}