using App.Domain.Identity;
using BLL.DTO;
using DAL.Contracts.App;
using DAL.Contracts.Base;
using Employee = App.Domain.Identity.Employee;

namespace BLL.Contracts.App;

public interface IUsersService : IBaseRepository<AppUser>, IUserRepositoryCustom<AppUser> 
{
    Task<IEnumerable<BasicUserInfo>> GetEmployeeByServiceAndSalon(Guid serviceId, Guid salonId);
    Task<AppUser> GetEmployeeByIdAsync(Guid employeeId);
    Task<AppUser> GetClientByIdAsync(Guid clientId);
    Task<AppUser> GetUserInRoleAsync(Guid userId, EUserRole role);
}