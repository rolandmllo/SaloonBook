using System.ComponentModel;

namespace App.Domain.Identity;

public enum EUserRole
{
    [Description("Client")]
    Client,
    [Description("Employee")]
    Employee,
    [Description("Admin")]
    Admin
    
}
