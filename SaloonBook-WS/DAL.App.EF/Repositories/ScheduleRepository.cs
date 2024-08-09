using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;

namespace DAL.App.EF.Repositories;

public class ScheduleRepository
    : EFBaseRepository<Schedule, ApplicationDbContext>, IScheduleRepository

{
    public ScheduleRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<IEnumerable<Schedule>> GetPublicSchedulesByEmployees(IEnumerable<EmployeeServices> employees)
    {
        var employee =  employees;
        var employeeIds = employee.Select(e => e.EmployeeId);
        var publicSchedules = RepositoryDbSet
            .Where(a => employeeIds.Contains(a.EmployeeId));
        return publicSchedules;    
        
    }
    
}