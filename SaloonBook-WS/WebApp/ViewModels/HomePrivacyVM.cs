using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace WebApp.ViewModels;

public class HomePrivacyVM
{
    public App.Domain.Identity.AppUser? AppUser { get; set; }
    public ICollection<IdentityUserClaim<Guid>>? AppUserClaims { get; set; }
}