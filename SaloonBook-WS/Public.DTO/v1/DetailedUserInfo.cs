namespace Public.DTO.v1;

public class DetailedUserInfo : BasicUserInfo
{
    public string Email { get; set; } = default!;
    public string? Phone { get; set; } = default!;
}