using App.Domain;
using DAL.Contracts.App;
using DAL.EF.Base;

namespace DAL.App.EF.Repositories;

public class EmployeeServicesRepository
    : EFBaseRepository<EmployeeServices, ApplicationDbContext>, IEmployeeServiceRepository

{
    public EmployeeServicesRepository(ApplicationDbContext dataContext) : base(dataContext)
    {
    }
    
}