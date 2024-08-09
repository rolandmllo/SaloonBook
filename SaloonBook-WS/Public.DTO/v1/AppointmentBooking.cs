namespace Public.DTO.v1;

public class AppointmentBooking
{
    public Guid Id { get; set; } = default!;
    public Guid ClientId { get; set; } = default!;
    public Guid EmployeeId { get; set; } = default!;
    public Guid CategoryId { get; set; } = default!;
    public Guid ServiceId { get; set; } = default!;
    public Guid SalonId { get; set; } = default!;
    
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public override string ToString()
    {
        return "id: " + Id.ToString();
    }
}