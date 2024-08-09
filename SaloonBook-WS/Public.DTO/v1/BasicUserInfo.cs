using Domain.Base;

namespace Public.DTO.v1;

public class BasicUserInfo : DomainEntityId
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

}