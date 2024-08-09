using Domain.Base;

namespace Public.DTO.v1;

public class BookingInfo : DomainEntityId
{
    public ICategoryDto Category { get; set; } = default!;
    public ISaloonByCityNameDto Saloon { get; set; } = default!;
    public IServiceListDto Service { get; set; } = default!;
    public IEmployeeDto Employee { get; set; } = default!;
    

}

public interface ICategoryDto
{
    public Guid Id { get; set; }
    public string? Label { get; set; }
}
public interface IEmployeeDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Label { get; set; }
}

public interface ISaloonByCityNameDto
{
    public string? City { get; set; }
    public IEnumerable<ISaloonDto>? Saloon { get; set; }
}


public interface ISaloonDto
{
    public Guid Id { get; set; }
    public string? SalonName { get; set; }
    public string? Label { get; set; }
}
public interface IServiceListDto
{
    public Guid Id { get; set; }
    public string? ServiceName { get; set; }
    public string? Label { get; set; }
}