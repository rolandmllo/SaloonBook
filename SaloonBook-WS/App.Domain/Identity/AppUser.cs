using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Base;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{
    [MaxLength(128)]
    public string FirstName { get; set; } = default!;

    [MaxLength(128)]
    public string LastName { get; set; } = default!;
    
    
    [MaxLength(128)]
    public string? Phone { get; set; } = default!;

    //public EUserRole AppRoleEnum { get; set; } = default;
    // public AppRole AppRole { get; set; } = default!;


    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<Schedule>? Schedule { get; set; }
    
    public ICollection<AppRefreshToken>? AppRefreshTokens { get; set; }
}