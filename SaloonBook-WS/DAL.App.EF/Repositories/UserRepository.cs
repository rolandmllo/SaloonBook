using App.Domain;
using App.Domain.Identity;
using DAL.Contracts.App;
using DAL.EF.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;


public class UserRepository : EFBaseRepository<AppUser, ApplicationDbContext>, IUserRepository

{
    private readonly UserManager<AppUser> _userManager;
    private ApplicationDbContext dbContext;

    public UserRepository(ApplicationDbContext dataContext, UserManager<AppUser> userManager) : base(dataContext)
    {
        _userManager = userManager;
        dbContext = dataContext;
    }


    public async Task<IEnumerable<AppUser>> GetAllEmployees()
    {
        return await _userManager.GetUsersInRoleAsync(nameof(EUserRole.Employee));
    }

    async Task<List<EmployeeServices>> GetEmployeeServicesByServiceAndSalon(Guid serviceId, Guid salonId)
        {
            //return await _userManager.GetUsersInRoleAsync(EUserRole.Employee.ToString());

            var employeeUsers = await dbContext.EmployeeServices
                .Include(u => u.Employee)
                .Include(s => s.Service)
                .Include(p => p.Service.EmployeeServices)
                .Include(p => p.Employee!.Schedule)
                .Where(u => GetAllEmployees().Result.Any(e => e == u.Employee))
                .Where(u => u.ServiceId == serviceId)
                .Where(u => u.Employee!.Schedule!.Any(s => s.SalonId == salonId))
                .ToListAsync();

            return employeeUsers;
        }    
    
    async Task<List<EmployeeServices>> GetEmployeeByServiceAndSalon(Guid serviceId, Guid salonId)
        {
            //return await _userManager.GetUsersInRoleAsync(EUserRole.Employee.ToString());

            var employeeUsers = await dbContext.EmployeeServices
                .Include(u => u.Employee)
                .Include(s => s.Service)
                .Include(p => p.Service.EmployeeServices)
                .Include(p => p.Employee!.Schedule)
                .Where(u => GetAllEmployees().Result.Any(e => e == u.Employee))
                .Where(u => u.ServiceId == serviceId)
                .Where(u => u.Employee!.Schedule!.Any(s => s.SalonId == salonId))
                .ToListAsync();

            return employeeUsers;
        }
}