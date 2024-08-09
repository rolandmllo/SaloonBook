namespace DAL.DTO;

public class SalonsByCities
{
    public Guid Id { get; set; }
    public string CityName { get; set; } = default!;
    public ICollection<Salon> Salon { get; set; } = default!;
}