using Domain.Base;

namespace BLL.DTO;

public class BasicUserInfo : DomainEntityId
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

}