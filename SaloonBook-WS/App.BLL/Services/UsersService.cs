using App.Domain.Identity;
using BLL.Base;
using BLL.Contracts.App;
using BLL.DTO;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Identity;


namespace BLL.App.Services;

public class UsersService : BaseEntityService<AppUser, AppUser, IUserRepository>, IUsersService
{
    protected IAppUOW Uow;
    private UserManager<AppUser> _userManager;

    public UsersService(IAppUOW uow, UserManager<AppUser> userManager) : 
        base(uow.UserRepository, null!)
    {
        Uow = uow;
        _userManager = userManager;
    }
    
    

    public async Task<IEnumerable<AppUser>> GetAllEmployees()
    {
        return await _userManager.GetUsersInRoleAsync(EUserRole.Employee.ToString());
    }
    

    public async Task<AppUser> GetEmployeeByIdAsync(Guid employeeId)
    {
        return await GetUserInRoleAsync(employeeId, EUserRole.Employee);
    }

    public async Task<AppUser> GetClientByIdAsync(Guid clientId)
    {
        return await GetUserInRoleAsync(clientId, EUserRole.Client);
    }

    public async Task<AppUser> GetUserInRoleAsync(Guid userId, EUserRole role)
    {
        var usersInRoleAsync = await _userManager.GetUsersInRoleAsync(role.ToString());
    
        var user = usersInRoleAsync.FirstOrDefault(i => i.Id == userId);
    
        return user!;
    }
    
    public Task<IEnumerable<BasicUserInfo>> GetEmployeeByServiceAndSalon(Guid serviceId, Guid salonId)
    {
        var employees = _userManager
            .GetUsersInRoleAsync(EUserRole.Employee.ToString());
            
        throw new NotImplementedException();
    }

}